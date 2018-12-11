using LovePlatform.Common.Enum;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class UserService
    {
        public readonly UserRepository _userRepository;
        public readonly IUnitWork _unitWork;

        public UserService(UserRepository userRepository, IUnitWork unitWork)
        {
            _userRepository = userRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>用户ID</returns>
        public OutputBase Add(User user)
        {
            var id = _userRepository.Add(user);
            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public async Task<OutputBase> Update(User user)
        {
            await _userRepository.Update(user);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }
        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <param name="state">用户状态</param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateUserState(int Id, UserStateEnum state)
        {
            await _userRepository.UpdateUserState(Id, state);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <param name="avatar">头像</param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateUserAvatar(int Id, string avatar)
        {
            await _userRepository.UpdateUserAvatar(Id, avatar);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns>用户</returns>
        public async Task<User> Get(int Id)
        {
            var user = await _userRepository.Get(Id);
            return user;
        }

        /// <summary>
        /// 根据Wechat OpenID获取用户
        /// </summary>
        /// <param name="wechatOpenId">微信OpenID</param>
        /// <returns>用户</returns>
        public async Task<User> Get(string wechatOpenId)
        {
            var user = await _userRepository.Get(wechatOpenId);
            return user;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        /// <summary>
        /// 根据条件用户列表 - 分页
        /// </summary>
        /// <param name="input">用户搜索输入</param>
        /// <returns>用户列表</returns>
        public async Task<Tuple<List<User>, int>> GetUserPageList(UserSearchInput input)
        {
            var query = await _userRepository.GetUserPageList(input);
            return query;
        }
    }
}
