using LovePlatform.Common.Enum;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class UserRepository
    {
        private readonly LovePlatformContext _Context;

        public UserRepository(LovePlatformContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>用户ID</returns>
        public int Add(User user)
        {
            DateTime now = DateTime.Now;
            user.Id = 0;
            user.AddTime = now;
            user.UpdateTime = now;
            _Context.Users.Add(user);

            return user.Id;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public async Task Update(User user)
        {
            var entity = await _Context.Users.FindAsync(user.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Type = user.Type;
            entity.Birthday = user.Birthday;
            entity.BirthPlace = user.BirthPlace;
            entity.Contact = user.Contact;
            entity.ContactReserve = user.ContactReserve;
            entity.ContactReserve1 = user.ContactReserve1;
            entity.Gender = user.Gender;
            entity.Name = user.Name;
            entity.ResidentialPlace = user.ResidentialPlace;
            _Context.Users.Update(entity);
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <param name="state">用户状态</param>
        /// <returns></returns>
        public async Task UpdateUserState(int Id, UserStateEnum state)
        {
            var entity = await _Context.Users.FindAsync(Id);
            entity.UpdateTime = DateTime.Now;
            entity.State = Convert.ToInt16(state);
            _Context.Users.Update(entity);
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <param name="avatar">头像</param>
        /// <returns></returns>
        public async Task UpdateUserAvatar(int Id, string avatar)
        {
            var entity = await _Context.Users.FindAsync(Id);
            entity.UpdateTime = DateTime.Now;
            entity.Avatar = avatar;
            _Context.Users.Update(entity);
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns>用户</returns>
        public async Task<User> Get(int Id)
        {
            var user = await _Context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return user;
        }

        /// <summary>
        /// 根据Wechat OpenID获取用户
        /// </summary>
        /// <param name="wexinOpenId">微信OpenID</param>
        /// <returns>用户</returns>
        public async Task<User> Get(string wexinOpenId)
        {
            var user = await _Context.Users.Where(x => x.WexinOpenId == wexinOpenId).FirstOrDefaultAsync();
            return user;
        }


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUser()
        {
            return await _Context.Users.ToListAsync();
        }

        /// <summary>
        /// 根据条件用户列表 - 分页
        /// </summary>
        /// <param name="input">用户搜索输入</param>
        /// <returns>用户列表</returns>
        public async Task<Tuple<List<User>, int>> GetUserPageList(UserSearchInput input)
        {
            var query = _Context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(x => x.Name.Contains(input.Name));
            }
            // to do: list query condition

            var total = query.Count();
            var userList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();
            return new Tuple<List<User>, int>(userList, total);
        }
    }
}
