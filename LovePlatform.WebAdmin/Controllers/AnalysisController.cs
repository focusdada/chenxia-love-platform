using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LovePlatform.Common;
using LovePlatform.Common.Enum;
using LovePlatform.Service;
using Microsoft.AspNetCore.Mvc;

namespace LovePlatform.WebAdmin.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly UserService _userService;
        private readonly DiagnoseService _diagnoseService;

        public AnalysisController(UserService userService, DiagnoseService diagnoseService)
        {
            _userService = userService;
            _diagnoseService = diagnoseService;
        }

        [HttpGet]
        public async Task<JsonResult> GetUserGender()
        {
            var users = await _userService.GetAllUser();
            var gender = from u in users
                         group u by u.Gender into g
                         select new
                         {
                             name = EnumHelper.GetDescription((SexEnum)g.Key),
                             value = g.Count()
                         };
            return Json(gender.ToList());       
        }

        public async Task<JsonResult> GetUserType()
        {
            var users = await _userService.GetAllUser();
            var type = from u in users
                         group u by u.Type into g
                         select new
                         {
                             name = EnumHelper.GetDescription((UserTypeEnum)g.Key),
                             value = g.Count()
                         };
            return Json(type.ToList());
        }

        public async Task<JsonResult> GetDiseaseType()
        {
            var diagnose = await _diagnoseService.GetAllDiagnose();
            var diseasesType = from u in diagnose
                       group u by u.DiseasesType into g
                       select new
                       {
                           name = EnumHelper.GetDescription((DiseasesTypeEnum)g.Key),
                           value = g.Count()
                       };
            return Json(diseasesType.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}