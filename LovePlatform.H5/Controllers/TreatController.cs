using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Domain.Models;
using Microsoft.Extensions.Options;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.H5.Utility;
using System.IO;
using LovePlatform.DTO.WebAPI;

namespace LovePlatform.H5.Controllers
{
    public class TreatController : Controller
    {
        private readonly MyOptions _optionsAccessor;
        private readonly WeixinHelper _weixinHelper;
        private readonly LovePlatformApi _lovePlatformApi;
        public TreatController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
            _weixinHelper = new WeixinHelper(_optionsAccessor.WeixinAppId, _optionsAccessor.WeixinAppSecret);
            _lovePlatformApi = new LovePlatformApi(_optionsAccessor.WebApiUrl);
        }

        public IActionResult Create(int userId)
        {
            var treat = new AddTreatDto() { UserId = userId };
            return View(treat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTreatDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = await _lovePlatformApi.AddTreat(model);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }
            var treatId = response.ResultValue;

            //上传文件
            //var files = Request.Form.Files;
            //foreach (var file in files)
            //{
            //    //转换成二进制
            //    Byte[] fileData = new Byte[(int)file.Length];
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        await file.CopyToAsync(memoryStream);
            //        fileData = memoryStream.ToArray();
            //    }

            //    //保存图片到服务器
            //    var r = await _lovePlatformApi.UploadImage(
            //        new UploadImageInput { AvatarBuffer = fileData, Folder = "cure-record" });

            //    var fileName = r.ResultValue;

            //    await _lovePlatformApi.AddTreatImage(new TreatImage() { ImagePath = fileName, TreatId = treatId, UserId = model.UserId });

            //}
            var user = await _lovePlatformApi.GetUser(model.UserId);
            return RedirectToAction("Index", "User", new { openId = user.WexinOpenId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var treat = await _lovePlatformApi.GetTreat(id);
            var treatImageList = await _lovePlatformApi.GetTreatImageList(id);
            ViewBag.TreatImageList = treatImageList;
            return View(treat);
        }

        [HttpPost]
        public async Task<IActionResult> UploadTreatImage(Treat model)
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

                await _lovePlatformApi.AddTreatImage(new TreatImage() { ImagePath = fileName, TreatId = model.Id, UserId = model.UserId });

            }
            return Content("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Treat model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = await _lovePlatformApi.UpdateTreat(model);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }
            // Delete treat image
            //var delResponse = _lovePlatformApi.DeleteTreatImage(model.Id);

            // Update treat image
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                Byte[] fileData = new Byte[(int)file.Length];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                // save image to OSS
                var r = await _lovePlatformApi.UploadImage(
                    new UploadImageInput { AvatarBuffer = fileData, Folder = "cure-record" });

                var fileName = r.ResultValue;

                await _lovePlatformApi.AddTreatImage(new TreatImage() { ImagePath = fileName, TreatId = model.Id, UserId = model.UserId });

            }
            var user = await _lovePlatformApi.GetUser(model.UserId);
            return RedirectToAction("Index", "User", new { openId = user.WexinOpenId });
        }
    }
}