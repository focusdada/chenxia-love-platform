using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class DiagnoseService
    {
        public readonly DiagnoseRepository _diagnoseRepository;
        public readonly IUnitWork _unitWork;

        public DiagnoseService(DiagnoseRepository diagnoseRepository, IUnitWork unitWork)
        {
            _diagnoseRepository = diagnoseRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增诊断
        /// </summary>
        /// <param name="diagnose">诊断</param>
        /// <returns>诊断ID</returns>
        public OutputBase Add(Diagnose diagnose)
        {
            var id = _diagnoseRepository.Add(diagnose);
            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 更新诊断
        /// </summary>
        /// <param name="diagnose">诊断</param>
        /// <returns></returns>
        public async Task<OutputBase> Update(Diagnose diagnose)
        {
            await _diagnoseRepository.Update(diagnose);
            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据用户ID获取诊断
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>诊断</returns>
        public async Task<Diagnose> Get(int userId)
        {
            var diagnose = await _diagnoseRepository.Get(userId);
            return diagnose;
        }

        public async Task<List<Diagnose>> GetAllDiagnose()
        {
            return await _diagnoseRepository.GetAllDiagnose();
        }
    }
}
