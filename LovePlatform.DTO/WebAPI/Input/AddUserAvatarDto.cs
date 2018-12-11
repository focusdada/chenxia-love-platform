using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// 用户头像DTO
    /// </summary>
    public class AddUserAvatarDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; }
    }
}
