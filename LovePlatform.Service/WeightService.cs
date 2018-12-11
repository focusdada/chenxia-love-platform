using AutoMapper;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class WeightService
    {
        public readonly WeightRepository _repository;
        public readonly PatientRepository _patientRepository;
        public readonly IUnitWork _unitWork;
        private readonly MyOptions _optionsAccessor;

        public WeightService(WeightRepository repository,PatientRepository patientRepository, IUnitWork unitWork, IOptions<MyOptions> optionsAccessor)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _unitWork = unitWork;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 新增体重
        /// </summary>
        /// <param name="input">体重输入</param>
        /// <returns>是否成功</returns>
        public OutputBase Add(AddWeightInput input)
        {
            var weight = Mapper.Map<AddWeightInput, Weight>(input);
            var measureTime = DateTime.Now;
            weight.MeasureTime = measureTime;
            _repository.Add(weight);

            return _unitWork.Commit() ? OutputBase.Success("新增报警记录成功") : OutputBase.Fail("新增报警记录失败");
        }

        /// <summary>
        /// 获取top数量体重记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重记录列表</returns>
        public async Task<List<AdminWeightDto>> GetAdminTopWeightList(CommonIndexInput input)
        {
            var weightList = await _repository.GetTopWeightList(input);

            return Mapper.Map<List<Weight>, List<AdminWeightDto>>(weightList);
        }
    }
}
