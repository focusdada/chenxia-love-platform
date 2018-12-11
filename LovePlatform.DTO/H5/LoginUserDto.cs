using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.H5
{
    public class LoginUserDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string WeixinOpenId { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string Avatar { get; set; }
    }
}
