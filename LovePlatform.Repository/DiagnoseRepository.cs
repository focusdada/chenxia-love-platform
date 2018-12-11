using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LovePlatform.Repository
{
    public class DiagnoseRepository
    {
        private readonly LovePlatformContext _Context;

        public DiagnoseRepository(LovePlatformContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// 新增诊断
        /// </summary>
        /// <param name="diagnose">诊断实体</param>
        /// <returns></returns>
        public int Add(Diagnose diagnose)
        {
            DateTime now = DateTime.Now;
            diagnose.Id = 0;
            diagnose.AddTime = now;
            diagnose.UpdateTime = now;
            _Context.Diagoses.Add(diagnose);

            return diagnose.Id;
        }

        /// <summary>
        /// 更新诊断
        /// </summary>
        /// <param name="diagnose">诊断实体</param>
        /// <returns></returns>
        public async Task Update(Diagnose diagnose)
        {
            var entity = await _Context.Diagoses.FindAsync(diagnose.Id);
            entity.UpdateTime = DateTime.Now;
            entity.FusionGene = diagnose.FusionGene;
            entity.Chromosomal = diagnose.Chromosomal;
            entity.DiseasesType = diagnose.DiseasesType;
            entity.Immunophenotyping = diagnose.Immunophenotyping;
            entity.SecondGenerationGeneSequencing = diagnose.SecondGenerationGeneSequencing;
            _Context.Diagoses.Update(entity);
        }

        /// <summary>
        /// 根据用户ID获取诊断数据
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>诊断数据</returns>
        public async Task<Diagnose> Get(int userId)
        {
            var diagnose = await _Context.Diagoses.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return diagnose;
        }

        public async Task<List<Diagnose>> GetAllDiagnose()
        {
            return await _Context.Diagoses.ToListAsync();
        }
    }
}
