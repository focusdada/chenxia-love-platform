using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI.Input;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 治疗
    /// </summary>
    [Produces("application/json")]
    [Route("api/Treat")]
    public class TreatController : Controller
    {
        private readonly TreatService _treatService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="treatService"></param>
        public TreatController(TreatService treatService)
        {
            _treatService = treatService;
        }

        /// <summary>
        /// 获取治疗
        /// </summary>
        /// <param name="id">治疗ID</param>
        /// <returns>治疗</returns>
        [HttpGet("{id}")]
        public async Task<WebAPIOutput<Treat>> Get(int id)
        {
            var treat = await _treatService.Get(id);
            return WebAPIOutput<Treat>.Success(treat);
        }

        /// <summary>
        /// 根据用户ID获取治疗数据
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>治疗数据</returns>
        [HttpGet("GetList/{userId}")]
        public async Task<WebAPIOutput<List<Treat>>> GetList(int userId)
        {
            var treatList = await _treatService.GetList(userId);
            return WebAPIOutput<List<Treat>>.Success(treatList);
        }

        /// <summary>
        /// 添加治疗
        /// </summary>
        /// <param name="treatDto">治疗实体</param>
        /// <returns>新增结果</returns>
        [HttpPost]
        public WebAPIOutput<int> Add([FromBody]AddTreatDto treatDto)
        {
            var treat = new Treat()
            {
                UserId = treatDto.UserId,
                TreatDate = treatDto.TreatDate,
                TreatDoctor = treatDto.TreatDoctor,
                TreatPlace = treatDto.TreatPlace,
                TreateDetail = treatDto.TreateDetail
            };
            var treatId = _treatService.Add(treat);
            return WebAPIOutput<int>.Success(treatId);
        }

        /// <summary>
        /// 更新诊断
        /// </summary>
        /// <param name="treat">用户诊断</param>
        /// <returns>更新结果</returns>
        [HttpPut("UpdateTreat")]
        public async Task<OutputBase> Update([FromBody]Treat treat)
        {
            return await _treatService.Update(treat);
        }
    }
}