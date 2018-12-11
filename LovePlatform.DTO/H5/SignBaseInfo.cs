using LovePlatform.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.H5
{
    /// <summary>
    /// 签约基础信息
    /// </summary>
    public class SignBaseInfo
    {
        /// <summary>
        /// 患者头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号/固定电话
        /// </summary>
        [Required(ErrorMessage = "请输入手机号或固定电话")]
        [MaxLength(12, ErrorMessage = "号码长度不能超过12")]
        [RegularExpression(RegexHelper.IsAllNumbers, ErrorMessage = "请输入正确的手机号或固定电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "请输入身份证号")]
        [RegularExpression(RegexHelper.IdentificationCardRegex, ErrorMessage = "请输入正确的身份证号")]
        public string IDNo { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        public string OpenId { get; set; }
    }
}
