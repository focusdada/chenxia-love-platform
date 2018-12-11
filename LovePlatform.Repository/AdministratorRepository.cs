using LovePlatform.Common;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.WebAPI.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class AdministratorRepository
    {
        private readonly LovePlatformContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public AdministratorRepository(LovePlatformContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="input">管理员登录输入</param>
        /// <returns>系统用户实体</returns>
        public async Task<Administrator> Login(AdminLoginInput input)
        {
            return await _context.Administrators
                //.Where(i => i.LoginName == input.LoginName && i.Password == EnctypeHelper.GetEncryptedStr(input.Password)).FirstOrDefaultAsync();
                .Where(i => i.LoginName == input.LoginName && i.Password == input.Password).FirstOrDefaultAsync();
        }

        public async Task<Administrator> Get(long id)
        {
            return await _context.Administrators.FindAsync(id);
        }

        public async Task<List<Administrator>> Get()
        {
            return await _context.Administrators.ToListAsync();
        }

        public long AddAdmin(Administrator admin)
        {
            DateTime now = DateTime.Now;
            admin.Id = 0;
            admin.AddTime = now;
            admin.UpdateTime = now;
            _context.Add(admin);

            return admin.Id;
        }

        public async Task UpdateAdmin(Administrator admin)
        {
            admin.UpdateTime = DateTime.Now;
            var entity = await _context.Administrators.FindAsync(admin.Id);
            entity.Password = admin.Password;
            entity.UserDesc = admin.UserDesc;
            entity.IsSuperManager = admin.IsSuperManager;
            _context.Administrators.Update(entity);
        }
    }
}
