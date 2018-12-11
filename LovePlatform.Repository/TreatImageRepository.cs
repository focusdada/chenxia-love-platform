using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class TreatImageRepository
    {
        private readonly LovePlatformContext _Context;

        public TreatImageRepository(LovePlatformContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// 新增治疗图片
        /// </summary>
        /// <param name="treatImage">治疗图片</param>
        /// <returns>治疗图片ID</returns>
        public int Add(TreatImage treatImage)
        {
            DateTime now = DateTime.Now;
            treatImage.Id = 0;
            treatImage.UploadTime = now;
            _Context.TreatImages.Add(treatImage);

            return treatImage.Id;
        }

        /// <summary>
        /// 获取用户治疗图片列表
        /// </summary>
        /// <param name="treatId">治疗ID</param>
        /// <returns>治疗图片列表</returns>
        public async Task<List<TreatImage>> GetList(int treatId)
        {
            var treatList = await _Context.TreatImages.Where(x => x.TreatId == treatId).OrderByDescending(x => x.UploadTime).ToListAsync();
            return treatList;
        }

        /// <summary>
        /// 获取用户治疗图片列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>治疗图片列表</returns>
        public async Task<List<TreatImage>> GetListByUser(int userId)
        {
            var treatList = await _Context.TreatImages.Where(x => x.UserId == userId).OrderByDescending(x => x.UploadTime).ToListAsync();
            return treatList;
        }

        public void DeleteByTreatId(int treatId)
        {
            var treatImgList = _Context.TreatImages.Where(x => x.TreatId.Equals(treatId));
            _Context.TreatImages.RemoveRange(treatImgList);
        }

        public void Delete(int treatImgId)
        {
            var treatImg = _Context.TreatImages.Where(x => x.Id.Equals(treatImgId)).FirstOrDefault();
            _Context.TreatImages.Remove(treatImg);
        }
    }
}
