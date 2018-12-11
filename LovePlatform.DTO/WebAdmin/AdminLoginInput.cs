using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    /// <summary>
    /// 管理员登录输入
    /// </summary>
    public class AdminLoginInput
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }

        /// <summary>
        /// 记住登陆状态
        /// </summary>
        public bool Remember { get; set; }
    }
}
