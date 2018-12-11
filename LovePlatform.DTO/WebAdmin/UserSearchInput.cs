using LovePlatform.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    public class UserSearchInput : SearchBase
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserTypeEnum? Type { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public SexEnum? Gender { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
    }
}
