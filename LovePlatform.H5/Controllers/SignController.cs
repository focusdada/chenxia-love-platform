using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.H5.Utility;
using Microsoft.Extensions.Options;
using LovePlatform.DTO.H5;
using System.IO;
using LovePlatform.DTO.WebAPI.Input;

namespace LovePlatform.H5.Controllers
{
    public class SignController : Controller
    {
        private readonly MyOptions _optionsAccessor;
        private readonly WeixinHelper _weixinHelper;
        private readonly LovePlatformApi _lovePlatformApi;

        public SignController(IOptions<MyOptions> optionsAccessor)
        {
            // 实际场景用
            _optionsAccessor = optionsAccessor.Value;
            _weixinHelper = new WeixinHelper(_optionsAccessor.WeixinAppId, _optionsAccessor.WeixinAppSecret);
            _lovePlatformApi = new LovePlatformApi(_optionsAccessor.WebApiUrl);

            // 开发环境用
            //_lovePlatformApi = new LovePlatformApi("http://106.14.14.219:8081/");
        }

        /// <summary>
        /// 检查用户签约状态
        /// </summary>
        /// <param name="code">微信回调code</param>
        /// <returns></returns>
        public async Task<IActionResult> CheckStatus(string code)
        {
            //code = HttpContext.Request.QueryString["Code"]
                //判断code是否存在
            // 实际场景用
            var openId = await _weixinHelper.GetOpenId(code);
            // 开发环境用
            //var openId = "xxxxx";

            var patient = await _lovePlatformApi.GetPatientByOpenId(openId);
            if (patient == null)
            {
                return RedirectToAction("VerifyId", "Sign", new { openId = openId });
            }
            else
            {
                return RedirectToAction("ApplySuccess", "Sign", new { message = "您已经签约并绑定微信，无需再签约" });
            }
        }

        public async Task<IActionResult> Check(string code)
        {
            //var openId = "xxxxx";
            var openId = await _weixinHelper.GetOpenId(code);
            var user = await _lovePlatformApi.GetUserByOpenId(openId);
            if (user == null)
            {
                return RedirectToAction("Register", "User", new { openId = openId });
            }
            else
            {
                return RedirectToAction("Index", "User", new { openId = openId });
            }
        }

        /// <summary>
        /// 识别身份证
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IActionResult VerifyId(string openId)
        {
            ViewBag.OpenId = openId;
            return View();
        }

        /// <summary>
        /// 提交识别身份证
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="idNo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> VerifyId(string openId, string idNo)
        {
            var patient = await _lovePlatformApi.GetPatientByIdNo(idNo);
            if (patient == null)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = string.Empty,
                    Url = Url.Action("BaseInfo", "Sign") + "?openId=" + openId + "&idNo=" + idNo
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(patient.WxOpenId))
                {
                    return Json(new
                    {
                        IsSuccess = false,
                        Message = "该身份证已经绑定微信，请重新输入"
                    });
                }

                var response = await _lovePlatformApi.PatientBindWeixin(new BindWeixinInput { IdNo = idNo, OpenId = openId });

                return Json(new
                {
                    IsSuccess = response.IsSuccess,
                    Message = response.IsSuccess ? string.Empty : response.Message,
                    Url = response.IsSuccess ? Url.Action("ApplySuccess", "Sign") + "?message=由于该身份证已经存在用户无需再填写其他信息，所以为您直接绑定微信" : string.Empty
                });
            }
        }

        /// <summary>
        /// 新建基础信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IActionResult BaseInfo(string openId, string idNo, SignBaseInfo model)
        {
            model.OpenId = openId;
            model.IDNo = idNo;

            return View(model);
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //转换成二进制
                Byte[] fileData = new Byte[(int)file.Length];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                //保存图片到服务器
                var response = await _lovePlatformApi.UploadImage(
                    new UploadImageInput { AvatarBuffer = fileData, Folder = "avatar" });
                if (response.IsSuccess)
                    return Content(response.ResultValue);
                return Content(string.Empty);
            }
            return Content(string.Empty);
        }

        /// <summary>
        /// 申请成功
        /// </summary>
        /// <returns></returns>
        public IActionResult ApplySuccess(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        /// <summary>
        /// 签约成功
        /// </summary>
        /// <returns></returns>
        public IActionResult AddSignSuccess(long signId, string avatar)
        {
            ViewBag.SignId = signId;
            ViewBag.Avatar = avatar;

            return View();
        }
    }
}