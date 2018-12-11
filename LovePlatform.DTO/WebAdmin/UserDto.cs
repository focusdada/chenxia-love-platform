using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    /// <summary>
    /// 用户展示类
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string WeChatOpenId { get; set; }

        /// <summary>
        /// 用户类型 0:患者 1:家属
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// 居住地
        /// </summary>
        public string ResidentialPlace { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 备用联系方式
        /// </summary>
        public string ContactReserve { get; set; }

        /// <summary>
        /// 备用联系方式
        /// </summary>
        public string ContactReserve1 { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public string State { get; set; }
    }
}
