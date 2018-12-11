using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// 上传图片请求
    /// </summary>
    public class UploadImageInput
    {
        /// <summary>
        /// 头像二进制数据
        /// </summary>
        [Required]
        public byte[] AvatarBuffer { get; set; }

        /// <summary>
        /// 需要上传的文件夹
        /// </summary>
        [Required]
        public string Folder { get; set; }
    }
}
