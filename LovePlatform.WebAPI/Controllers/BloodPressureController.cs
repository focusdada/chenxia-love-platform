using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 血压
    /// </summary>
    [Produces("application/json")]
    [Route("api/BloodPressure")]
    public class BloodPressureController : Controller
    {
        private readonly BloodPressureService _bloodPressureService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bloodPressureService"></param>
        public BloodPressureController(BloodPressureService bloodPressureService)
        {
            _bloodPressureService = bloodPressureService;
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input">新增血压请求</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OutputBase> Add([FromBody]AddBloodPressureInput input)
        {
            return await _bloodPressureService.Add(input);
        }

        /// <summary>
        /// 获取最新top数量血压列表
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        [HttpGet("{patientId}/{topNumber}")]
        public async Task<WebAPIOutput<List<BloodPressureDto>>> GetTopList(long patientId, int topNumber)
        {
            return await _bloodPressureService.GetTopList(patientId, topNumber);
        }
    }
}