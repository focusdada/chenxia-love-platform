using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.Common;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.WebAdmin.Middleware;

namespace LovePlatform.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class PatientController : BaseController
    {
        private readonly PatientService _service;
        private readonly WeightService _weightService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public PatientController(PatientService service, WeightService weightService)
        {
            _service = service;
            _weightService = weightService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int pageIndex = 1)
        {
            var search = new PatientSearchInput { PageIndex = pageIndex };

            return View(search);
        }

        /// <summary>
        /// 患者列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(PatientSearchInput input)
        {
            var model = new Page<PatientViewDto>();

            var items = await _service.GetPatientPageList(input);
            model.CurrentPage = input.PageIndex;
            model.Items = items.Item1;
            model.TotalRecords = items.Item2;

            return PartialView("_ListPartial", model);
        }


        /// <summary>
        /// 患者详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(long id, int pageIndex)
        {
            //ViewBag.PageIndex = pageIndex;
            var patient = await _service.GetAdminPatientDetailById(id);

            return View(patient);
        }

        /// <summary>
        /// 体重记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetWeightList(long patientId)
        {
            //默认30条最新记录
            var weightList = await _weightService.GetAdminTopWeightList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            weightList.Reverse();

            return Json(weightList);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            //ViewBag.SexList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
            //ViewBag.UserStatusList = EnumExtensionHelper.EnumToSelectList<UserStatusEnum>(false);
            if (id > 0)
            {
                var model = await _service.GetAdminPatientById(id);
                return PartialView("_EditPartial", model);
            }
            else
            {

                return PartialView("_EditPartial", new AdminPatientDto());
            }
        }

        /// <summary>
        /// 提交编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdminPatientDto model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_EditPartial", model);
            }

            //主键初始Id大于0表示是编辑，反之则是新增
            if (model.Id > 0)
            {
                var result = await _service.Update(model);
                return Json(result);
            }
            else
            {
                var result = _service.Add(model);
                return Json(result);
            }
        }
    }
}