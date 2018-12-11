using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class TreatImageService
    {
        private readonly TreatImageRepository _treatImageRepository;
        private readonly IUnitWork _unitWork;

        public TreatImageService(TreatImageRepository treatImageRepository, IUnitWork unitWork)
        {
            _treatImageRepository = treatImageRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增治疗图片
        /// </summary>
        /// <param name="treatImage">治疗图片</param>
        /// <returns>治疗图片ID</returns>
        public OutputBase Add(TreatImage treatImage)
        {
            _treatImageRepository.Add(treatImage);
            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 获取用户治疗图片列表
        /// </summary>
        /// <param name="treatId">治疗ID</param>
        /// <returns>治疗图片列表</returns>
        public async Task<List<TreatImage>> GetList(int treatId)
        {
            return await _treatImageRepository.GetList(treatId);
        }

        /// <summary>
        /// 获取用户治疗图片列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>治疗图片列表</returns>
        public async Task<List<TreatImage>> GetListByUser(int userId)
        {
            return await _treatImageRepository.GetListByUser(userId);
        }

        public OutputBase Delete(int treatImgId)
        {
            _treatImageRepository.Delete(treatImgId);
            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }

        public OutputBase DeleteByTreatId(int treatId)
        {
            _treatImageRepository.DeleteByTreatId(treatId);
            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }
    }
}
