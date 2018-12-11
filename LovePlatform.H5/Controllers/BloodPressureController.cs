using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.Common.Enum;

namespace LovePlatform.H5.Controllers
{
    public class BloodPressureController : Controller
    {
        private readonly MyOptions _optionsAccessor;
        private readonly LovePlatformApi _loveplatformApi;

        public BloodPressureController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
            //_loveplatformApi = new LovePlatformApi(_optionsAccessor.WebApiUrl);
            _loveplatformApi = new LovePlatformApi("http://106.14.14.219:8081/");
        }

        /// <summary>
        /// 血压列表页面
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List(long patientId)
        {
            ViewBag.PatientId = patientId;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListPartial(long patientId, int topNumber)
        {
            var list = await _loveplatformApi.GetBloodPressureList(patientId, topNumber);

            return PartialView("_ListPartial", list);
        }

        /// <summary>
        /// 血压新增页面
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add(long patientId)
        {
            var model = new AddBloodPressureInput { PatientId = patientId };

            return View(model);
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddBloodPressureInput input)
        {
            ModelState.Remove("DataSource");
            ViewBag.IsAdded = false;
            input.DataSource = (int)DataSourceTypeEnum.WeixinInput;
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var response = await _loveplatformApi.AddBloodPressure(input);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(input);
            }
            ViewBag.IsAdded = true;
            return View(input);
        }
    }
}