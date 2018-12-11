using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Domain.Models;
using LovePlatform.H5.Utility;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using LovePlatform.Common.Enum;
using LovePlatform.Common;

namespace LovePlatform.H5.Controllers
{
    public class DiagnoseController : Controller
    {
        private readonly MyOptions _optionsAccessor;
        private readonly WeixinHelper _weixinHelper;
        private readonly LovePlatformApi _lovePlatformApi;
        public DiagnoseController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
            _weixinHelper = new WeixinHelper(_optionsAccessor.WeixinAppId, _optionsAccessor.WeixinAppSecret);
            _lovePlatformApi = new LovePlatformApi(_optionsAccessor.WebApiUrl);
        }

        public async Task<IActionResult> Create(int userId)
        {
            var selectItemList = new List<SelectListItem>();
            var diesasesTypeList = EnumHelper.EnumToArrayList<DiseasesTypeEnum>(false);
            diesasesTypeList.ForEach(x => selectItemList.Add(new SelectListItem() { Text = x.Text, Value = x.Value }));
            ViewBag.DiesasesTypeList = selectItemList;
            var diagnose = await _lovePlatformApi.GetDiagnose(userId) ?? new Diagnose() { UserId = userId };
            return View(diagnose);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Diagnose model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var diagnose = await _lovePlatformApi.GetDiagnose(model.UserId);
            var response = diagnose == null ? await _lovePlatformApi.AddDiagnose(model) : await _lovePlatformApi.UpdateDiagnose(model);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }

            var user = await _lovePlatformApi.GetUser(model.UserId);
            return RedirectToAction("Index", "User", new { openId = user.WexinOpenId });
        }
    }
}