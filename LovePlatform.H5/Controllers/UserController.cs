using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Domain.Models;
using Microsoft.Extensions.Options;
using LovePlatform.DTO.H5;
using AutoMapper;
using System.IO;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.H5.Utility;

namespace LovePlatform.H5.Controllers
{
    public class UserController : Controller
    {
        private readonly MyOptions _optionsAccessor;
        private readonly WeixinHelper _weixinHelper;
        private readonly LovePlatformApi _lovePlatformApi;
        public UserController(IOptions<MyOptions> optionsAccessor)
        {
            // 实际场景用
            _optionsAccessor = optionsAccessor.Value;
            _weixinHelper = new WeixinHelper(_optionsAccessor.WeixinAppId, _optionsAccessor.WeixinAppSecret);
            _lovePlatformApi = new LovePlatformApi(_optionsAccessor.WebApiUrl);

            // 开发环境用
            //_lovePlatformApi = new LovePlatformApi("http://localhost:34188/");
        }

        public async Task<IActionResult> Index(string openId)
        {
            ViewData["Title"] = "我的数据";
            var user = await _lovePlatformApi.GetUserByOpenId(openId);
            if (user == null)
            {
                RedirectToAction("Register", "User", new { openId = openId });
            }

            var diagnose = await _lovePlatformApi.GetDiagnose(user.Id) ?? new Diagnose();
            diagnose.Chromosomal = string.IsNullOrEmpty(diagnose.Chromosomal) ? "点击完善" : "点击查看";
            diagnose.FusionGene = string.IsNullOrEmpty(diagnose.FusionGene) ? "点击完善" : "点击查看";
            diagnose.Immunophenotyping = string.IsNullOrEmpty(diagnose.Immunophenotyping) ? "点击完善" : "点击查看";
            diagnose.SecondGenerationGeneSequencing = string.IsNullOrEmpty(diagnose.SecondGenerationGeneSequencing) ? "点击完善" : "点击查看";

            var treatList = await _lovePlatformApi.GetTreatList(user.Id) ?? new List<Treat>();

            var dto = new Tuple<User, DiagnoseDto, List<Treat>>(user, Mapper.Map<Diagnose, DiagnoseDto>(diagnose), treatList);

            return View(dto);
        }

        public IActionResult Register(string openId)
        {
            ViewData["Title"] = "病友注册";
            var model = new User() { WexinOpenId = openId };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("WexinOpenId,Type,Name,Gender,Birthday,BirthPlace,ResidentialPlace,Contact,ContactReserve,ContactReserve1")]User user)
        {
            ViewData["Title"] = "病友注册";
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _lovePlatformApi.AddUser(user);
            return RedirectToAction("Index", new { openId = user.WexinOpenId });
        }

        //public async Task<IActionResult> Edit(string openId)
        //{
        //    ViewData["Title"] = "个人信息";
        //    var user = await _lovePlatformApi.GetUserByOpenId(openId);
        //    if (user != null)
        //    {
        //        return View(user);
        //    }
        //    return RedirectToAction("Register", "User", new { openId = openId });
        //}

        public async Task<IActionResult> Edit(string code)
        {
            ViewData["Title"] = "个人信息";
            var openId = await _weixinHelper.GetOpenId(code);
            var user = await _lovePlatformApi.GetUserByOpenId(openId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Register", "User", new { openId = openId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            ViewData["Title"] = "个人信息";
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var response = await _lovePlatformApi.UpdateUser(user);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(user);
            }
            return RedirectToAction("Index", "User", new { OpenId = user.WexinOpenId });
        }


        /// <summary>
        /// 上传用户头像
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAvatar(int userId)
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
                var r = await _lovePlatformApi.UploadImage(
                    new UploadImageInput { AvatarBuffer = fileData, Folder = "cure-record" });

                var fileName = r.ResultValue;

                await _lovePlatformApi.UpdateUserAvatar(new AddUserAvatarDto { Id = userId, Avatar = fileName });

                return Content(fileName);

            }
            return Content(string.Empty);
        }
    }
}