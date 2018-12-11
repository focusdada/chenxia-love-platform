using LovePlatform.Common;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class WeightRepository
    {
        private readonly LovePlatformContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public WeightRepository(LovePlatformContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增体重
        /// </summary>
        /// <param name="weight"></param>
        public void Add(Weight weight)
        {
            weight.Id = _idGenerator.CreateId();
            _context.Weights.Add(weight);
        }

        /// <summary>
        /// 体重数据是否存在
        /// </summary>
        /// <param name="dialysisWeightId">透析体重Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<bool> IsExist(int id)
        {
            return await _context.Weights.AnyAsync(t => t.Id==id);
        }

        /// <summary>
        /// 判断是否存在体重数据(App用)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsExistWeightData(long patientId)
        {
            return await _context.Weights.AnyAsync(i => i.PatientId == patientId); ;
        }

        /// <summary>
        /// 获取top数量体重实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重实体列表</returns>
        public async Task<List<Weight>> GetTopWeightList(CommonIndexInput input)
        {
            var weightList = await _context.Weights
                .Where(i => i.PatientId == input.PatientId)
                    .OrderByDescending(i => i.MeasureTime)
                        .Take(input.TopNumber)
                            .ToListAsync();

            return weightList;
        }
    }
}
