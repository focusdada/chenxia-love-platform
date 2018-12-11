using LovePlatform.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    public class BindWeixinInput
    {
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required]
        [RegularExpression(RegexHelper.IdentificationCardRegex, ErrorMessage = "身份证号码不正确")]
        public string IdNo { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Required]
        public string OpenId { get; set; }
    }
}
