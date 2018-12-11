using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI.Input;

namespace LovePlatform.WebAPI.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 根据微信OpenID获取用户
        /// </summary>
        /// <param name="weixinOpenId">微信OpenID</param>
        /// <returns>用户信息</returns>
        [HttpGet("{weixinOpenId}")]
        public async Task<WebAPIOutput<User>> GetUserByWeixinOpenId(string weixinOpenId)
        {
            var user = await _userService.Get(weixinOpenId);
            return WebAPIOutput<User>.Success(user);
        }

        /// <summary>
        /// 根据用户Id获取用户
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>用户信息</returns>
        [HttpGet("GetUser/{userId}")]
        public async Task<WebAPIOutput<User>> GetUser(int userId)
        {
            var user = await _userService.Get(userId);
            return WebAPIOutput<User>.Success(user);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>新增结果</returns>
        [HttpPost("AddUser")]
        public OutputBase AddUser([FromBody]User user)
        {
            return _userService.Add(user);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>更新结果</returns>
        [HttpPut("UpdateUser")]
        public async Task<OutputBase> UpdateUser([FromBody]User user)
        {
            return await _userService.Update(user);
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="userAvatarDto">用户头像</param>
        /// <returns></returns>
        [HttpPut("UpdateUserAvatar")]
        public async Task<OutputBase> UpdateUserAvatar([FromBody]AddUserAvatarDto userAvatarDto)
        {
            return await _userService.UpdateUserAvatar(userAvatarDto.Id, userAvatarDto.Avatar);
        }
    }
}