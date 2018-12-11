using LovePlatform.Common;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class BloodPressureRepository
    {
        private readonly LovePlatformContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public BloodPressureRepository(LovePlatformContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="entity"></param>
        public void Add(BloodPressure entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.AddTime = DateTime.Now;
            _context.BloodPressures.Add(entity);
        }

        /// <summary>
        /// 获取最新血压
        /// </summary>
        /// <returns></returns>
        public async Task<BloodPressure> GetLatest(long patientId)
        {
            var bloodPressure = await _context.BloodPressures.Where(i => i.PatientId == patientId).OrderByDescending(i => i.AddTime).FirstOrDefaultAsync();

            return bloodPressure;
        }

        /// <summary>
        /// 获取最新top数量血压列表
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public async Task<List<BloodPressure>> GetTopList(long patientId, int topNumber)
        {
            var bloodPressureList = await _context.BloodPressures.Where(i => i.PatientId == patientId).OrderByDescending(i => i.AddTime).Take(topNumber).ToListAsync();

            return bloodPressureList;
        }
    }
}
