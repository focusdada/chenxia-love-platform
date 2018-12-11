using AutoMapper;
using LovePlatform.Common;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
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
    public class BloodPressureService
    {
        private readonly IUnitWork _unitWork;
        private readonly PatientRepository _patientRepository;
        private readonly BloodPressureRepository _bloodPressureRepository;
        private readonly MyOptions _optionsAccessor;

        public BloodPressureService(IUnitWork unitWork, BloodPressureRepository bloodPressureRepository, 
            PatientRepository patientRepository, IOptions<MyOptions> optionsAccessor)
        {
            _unitWork = unitWork;
            _patientRepository = patientRepository;
            _bloodPressureRepository = bloodPressureRepository;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input">新增血压请求</param>
        /// <returns></returns>
        public async Task<OutputBase> Add(AddBloodPressureInput input)
        {
            var patient = await _patientRepository.Get((int)input.PatientId);
            if (patient == null)
                return OutputBase.Fail("该患者不存在");

            var entity = new BloodPressure
            {
                DataSource = input.DataSource,
                PatientId = input.PatientId,
                DiastolicPressure = input.DiastolicPressure,
                DiastolicPressureIsNormal = ChronicDiseaseUtility.IsDiastolicPressureNormal(input.DiastolicPressure),
                SystolicPressure = input.SystolicPressure,
                SystolicPressureIsNormal = ChronicDiseaseUtility.IsSystolicPressureNormal(input.SystolicPressure),
                HeartRate = input.HeartRate,
                HeartRateIsNormal = ChronicDiseaseUtility.IsHeartRateNormal(input.HeartRate)
            };
            _bloodPressureRepository.Add(entity);

            return _unitWork.Commit() ? OutputBase.Success("已成功录入血压") : OutputBase.Fail("录入血压失败");
        }

        /// <summary>
        /// 获取最新top数量血压列表
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public async Task<WebAPIOutput<List<BloodPressureDto>>> GetTopList(long patientId, int topNumber)
        {
            var bloodPressureList = await _bloodPressureRepository.GetTopList(patientId, topNumber);

            return WebAPIOutput<List<BloodPressureDto>>.Success(Mapper.Map<List<BloodPressure>, List<BloodPressureDto>>(bloodPressureList));
        }
    }
}
