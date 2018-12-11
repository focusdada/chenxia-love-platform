using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 治疗图片接口 
    /// </summary>
    [Produces("application/json")]
    [Route("api/TreatImage")]
    public class TreatImageController : Controller
    {
        private readonly TreatImageService _treatImageService;

        /// <summary>
        /// 构造函数 
        /// </summary>
        /// <param name="treatImageService"></param>
        public TreatImageController(TreatImageService treatImageService)
        {
            _treatImageService = treatImageService;
        }

        /// <summary>
        /// 根据用户ID获取治疗图片
        /// </summary>
        /// <param name="treatId">治疗ID</param>
        /// <returns>治疗图片</returns>
        [HttpGet("GetList/{treatId}")]
        public async Task<WebAPIOutput<List<TreatImage>>> GetList(int treatId)
        {
            var treatImageList = await _treatImageService.GetList(treatId);
            return WebAPIOutput<List<TreatImage>>.Success(treatImageList);
        }

        /// <summary>
        /// 添加治疗图片
        /// </summary>
        /// <param name="treatImage">治疗图片实体</param>
        /// <returns>新增结果</returns>
        [HttpPost]
        public OutputBase Add([FromBody]TreatImage treatImage)
        {
            return _treatImageService.Add(treatImage);
        }

        /// <summary>
        /// Delete images by treatId
        /// </summary>
        /// <param name="treatId"></param>
        /// <returns></returns>
        [HttpDelete]
        public OutputBase Delete(int treatId)
        {
            return _treatImageService.DeleteByTreatId(treatId);
        }
    }
}