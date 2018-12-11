using LovePlatform.Common;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class OssService
    {
        private readonly IUnitWork _unitWork;
        private readonly OssRepository _ossRepository;

        public OssService(IUnitWork unitWork, OssRepository ossRepository)
        {
            _unitWork = unitWork;
            _ossRepository = ossRepository;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="input">上传图片请求</param>
        /// <returns></returns>
        public async Task<WebAPIOutput<string>> UploadImage(UploadImageInput input)
        {
            var avatar = await _ossRepository.UploadImage(input);

            return string.IsNullOrEmpty(avatar) ? WebAPIOutput<string>.Fail("上传失败") : WebAPIOutput<string>.Success(CommConstant.OssUrl + avatar);
        }
    }
}
