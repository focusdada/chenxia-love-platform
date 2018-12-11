using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// Oss
    /// </summary>
    [Produces("application/json")]
    [Route("api/Oss")]
    public class OssController : Controller
    {
        private readonly OssService _ossService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ossService"></param>
        public OssController(OssService ossService)
        {
            _ossService = ossService;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="input">上传图片请求</param>
        /// <returns></returns>
        [HttpPost("UploadImage")]
        public async Task<WebAPIOutput<string>> UploadImage([FromBody]UploadImageInput input)
        {
            return await _ossService.UploadImage(input);
        }
    }
}
