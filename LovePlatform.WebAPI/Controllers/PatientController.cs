using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Output;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.DTO.Common;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 患者
    /// </summary>
    [Produces("application/json")]
    [Route("api/Patient")]
    public class PatientController : Controller
    {
        private readonly PatientService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public PatientController(PatientService service)
        {
            _service = service;
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        [HttpGet("{patientId}")]
        public async Task<WebAPIOutput<PatientDto>> GetPatientById(long patientId)
        {
            return await _service.GetPatientById(patientId);
        }

        /// <summary>
        /// 修改患者体重
        /// </summary>
        /// <param name="input">修改患者干体重请求</param>
        /// <returns>是否成功</returns>
        [HttpPut("UpdateWeight")]
        public async Task<OutputBase> UpdateWeight([FromBody]UpdateWeightInput input)
        {
            return await _service.UpdateWeight(input);
        }

        /// <summary>
        /// 根据OpenId获取患者
        /// </summary>
        /// <param name="openId">微信OpenId</param>
        /// <returns></returns>
        [HttpGet("OpenId/{openId}")]
        public async Task<WebAPIOutput<DictDto>> GetByOpenId(string openId)
        {
            var result = await _service.GetByOpenId(openId);
            return WebAPIOutput<DictDto>.Success(result);
        }

        /// <summary>
        /// 患者微信绑定
        /// </summary>
        /// <param name="input">绑定输入</param>
        /// <returns></returns>
        [HttpPut("BindWeixin")]
        public async Task<OutputBase> BindWeixin(BindWeixinInput input)
        {
            var result = await _service.BindWeixin(input);
            return WebAPIOutput<OutputBase>.Success(result);
        }


        /// <summary>
        /// 根据身份证号码获取患者
        /// </summary>
        /// <param name="idNo">身份证号码</param>
        /// <returns></returns>
        [HttpGet("IdNo/{idNo}")]
        public async Task<WebAPIOutput<GetPatientByIdNoOutput>> GetByIdNo(string idNo)
        {
            var result = await _service.GetByIdNo(idNo);
            return WebAPIOutput<GetPatientByIdNoOutput>.Success(result);
        }
    }
}
