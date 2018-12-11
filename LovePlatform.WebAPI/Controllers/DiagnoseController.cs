using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Domain.Models;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 诊断
    /// </summary>
    [Produces("application/json")]
    [Route("api/Diagnose")]
    public class DiagnoseController : Controller
    {
        private readonly DiagnoseService _diagnoseService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="diagnoseService"></param>
        public DiagnoseController(DiagnoseService diagnoseService)
        {
            _diagnoseService = diagnoseService;
        }

        /// <summary>
        /// 根据用户ID获取诊断数据
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>诊断数据</returns>
        [HttpGet("{userId}")]
        public async Task<WebAPIOutput<Diagnose>> Get(int userId)
        {
            var diagnose = await _diagnoseService.Get(userId);
            return WebAPIOutput<Diagnose>.Success(diagnose);
        }

        /// <summary>
        /// 添加诊断
        /// </summary>
        /// <param name="diagnose">诊断实体</param>
        /// <returns>新增结果</returns>
        [HttpPost]
        public OutputBase Add([FromBody]Diagnose diagnose)
        {
            return _diagnoseService.Add(diagnose);
        }

        /// <summary>
        /// 更新诊断
        /// </summary>
        /// <param name="diagnose">用户诊断</param>
        /// <returns>更新结果</returns>
        [HttpPut("UpdateDiagnose")]
        public async Task<OutputBase> Update([FromBody]Diagnose diagnose)
        {
            return await _diagnoseService.Update(diagnose);
        }
    }
}