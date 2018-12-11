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
    public class TreatRepository
    {
        private readonly LovePlatformContext _Context;

        public TreatRepository(LovePlatformContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// 新增治疗
        /// </summary>
        /// <param name="treat">治疗</param>
        /// <returns>治疗ID</returns>
        public int Add(Treat treat)
        {
            DateTime now = DateTime.Now;
            treat.Id = 0;
            treat.AddTime = now;
            treat.UpdateTime = now;
            _Context.Treats.Add(treat);
            return treat.Id;
        }

        /// <summary>
        /// 更新治疗
        /// </summary>
        /// <param name="treat">治疗</param>
        /// <returns></returns>
        public async Task Update(Treat treat)
        {
            var entity = await _Context.Treats.FindAsync(treat.Id);
            entity.UpdateTime = DateTime.Now;
            entity.TreatDate = treat.TreatDate;
            entity.TreatDoctor = treat.TreatDoctor;
            entity.TreateDetail = treat.TreateDetail;
            entity.TreatPlace = treat.TreatPlace;
            entity.TreatePic1 = treat.TreatePic1;
            entity.TreatePic2 = treat.TreatePic2;
            entity.TreatePic3 = treat.TreatePic3;
            entity.TreatePic4 = treat.TreatePic4;
            _Context.Treats.Update(entity);
        }

        /// <summary>
        /// 根据ID获取治疗
        /// </summary>
        /// <param name="Id">治疗ID</param>
        /// <returns>治疗</returns>
        public async Task<Treat> Get(int Id)
        {
            var treat = await _Context.Treats.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return treat;
        }

        /// <summary>
        /// 获取用户治疗列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>治疗列表</returns>
        public async Task<List<Treat>> GetList(int userId)
        {
            var treatList = await _Context.Treats.Where(x => x.UserId == userId).OrderByDescending(x => x.TreatDate).ToListAsync();
            return treatList;
        }
    }
}
