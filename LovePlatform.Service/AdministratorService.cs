using AutoMapper;
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
    public class AdministratorService
    {
        public readonly AdministratorRepository _repository;
        public readonly IUnitWork _unitWork;

        public AdministratorService(AdministratorRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        public async Task<AdminLoginUserInfo> Login(AdminLoginInput input)
        {
            return Mapper.Map<Administrator, AdminLoginUserInfo>(await _repository.Login(input));
        }

        public async Task<Administrator> Get(long id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Administrator>> Get()
        {
            return await _repository.Get();
        }

        public OutputBase AddAdmin(Administrator admin)
        {
            var id = _repository.AddAdmin(admin);
            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        public async Task<OutputBase> UpdateAdmin(Administrator admin)
        {
            await _repository.UpdateAdmin(admin);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }
    }
}