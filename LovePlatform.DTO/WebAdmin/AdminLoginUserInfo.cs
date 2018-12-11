using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    /// <summary>
    /// 后台登录用户信息
    /// </summary>
    public class AdminLoginUserInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 是否超管
        /// </summary>
        public bool IsSuperManager { get; set; }

        /// <summary>
        /// 医院Id（超管为null）
        /// </summary>
        public long? HospitalId { get; set; }
    }
}
