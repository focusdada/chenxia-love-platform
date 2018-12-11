using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class TreatService
    {
        private readonly TreatRepository _treatRepository;
        private readonly IUnitWork _unitWork;

        public TreatService(TreatRepository treatRepository, IUnitWork unitWork)
        {
            _treatRepository = treatRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增治疗
        /// </summary>
        /// <param name="treat">治疗</param>
        /// <returns>治疗ID</returns>
        public int Add(Treat treat)
        {
            _treatRepository.Add(treat);
            return _unitWork.Commit() ? treat.Id : -1;
        }

        /// <summary>
        /// 更新治疗
        /// </summary>
        /// <param name="treat">治疗</param>
        /// <returns></returns>
        public async Task<OutputBase> Update(Treat treat)
        {
            await _treatRepository.Update(treat);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据ID获取治疗
        /// </summary>
        /// <param name="Id">治疗ID</param>
        /// <returns>治疗</returns>
        public async Task<Treat> Get(int Id)
        {
            return await _treatRepository.Get(Id);
        }

        /// <summary>
        /// 获取用户治疗列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>治疗列表</returns>
        public async Task<List<Treat>> GetList(int userId)
        {
            return await _treatRepository.GetList(userId);
        }
    }
}
