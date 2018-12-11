using AutoMapper;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.Common;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.DTO.WebAPI.Output;
using LovePlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.Service
{
    public class PatientService
    {   
        public readonly PatientRepository _repository;
        public readonly WeightRepository _weightRepository;
        public readonly IUnitWork _unitWork;

        public PatientService(PatientRepository repository, WeightRepository weightRepository, IUnitWork unitWork)
        {
            _repository = repository;
            _weightRepository = weightRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 更新体重
        /// </summary>
        /// <param name="input">更新体重输入</param>
        /// <returns>是否更新成功</returns>
        public async Task<OutputBase> UpdateWeight(UpdateWeightInput input)
        {
            await _repository.UpdateWeight(input);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<WebAPIOutput<PatientDto>> GetPatientById(long patientId)
        {
            var patient = Mapper.Map<Patient, PatientDto>(await _repository.GetPatientById(patientId));
            patient.HasWeightData = await _weightRepository.IsExistWeightData(patientId);

            return WebAPIOutput<PatientDto>.Success(patient);
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息（后台）详情
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<PatientDetailViewDto> GetAdminPatientDetailById(long patientId)
        {
            var entity = await _repository.GetPatientById(patientId);
            var patient = Mapper.Map<Patient, PatientDetailViewDto>(entity);

            return patient;
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息（后台）
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<AdminPatientDto> GetAdminPatientById(long patientId)
        {
            var patient = Mapper.Map<Patient, AdminPatientDto>(await _repository.GetPatientById(patientId));

            return patient;
        }

        /// <summary>
        /// 新增患者
        /// </summary>
        /// <param name="input">患者信息</param>
        /// <returns>是否成功</returns>
        public OutputBase Add(AdminPatientDto input)
        {
            var patient = new Patient
            {
                Brithdate = input.Brithdate,
                PatientName = input.PatientName,
                Sex = input.Sex,
            };
            var patientId = _repository.Add(patient);

            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="input">患者信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminPatientDto input)
        {
            var patient = new Patient
            {
                Id = input.Id,
                Brithdate = input.Brithdate,
                PatientName = input.PatientName,
                Sex = input.Sex
            };
            await _repository.UpdatePatient(patient);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 删除患者
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(long id)
        {
            _repository.Delete(id);

            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }

        /// <summary>
        /// 根据患者搜索输入分页获取患者列表
        /// </summary>
        /// <param name="input">患者搜索输入</param>
        /// <returns>患者列表</returns>
        public async Task<Tuple<List<PatientViewDto>, int>> GetPatientPageList(PatientSearchInput input)
        {
            var result = await _repository.GetPatientPageList(input);

            var tuple = new Tuple<List<PatientViewDto>, int>(Mapper.Map<List<Patient>, List<PatientViewDto>>(result.Item1), result.Item2);

            return tuple;
        }

        /// <summary>
        /// 根据OpenId获取患者
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public async Task<DictDto> GetByOpenId(string openId)
        {
            return Mapper.Map<Patient, DictDto>(await _repository.GetByOpenId(openId));
        }

        /// <summary>
        /// 患者微信绑定
        /// </summary>
        /// <param name="input">绑定输入</param>
        /// <returns></returns>
        public async Task<OutputBase> BindWeixin(BindWeixinInput input)
        {
            var patient = await _repository.GetByIdNo(input.IdNo);
            if (patient == null)
            {
                return OutputBase.Fail("不存在该患者");
            }
            if (!string.IsNullOrEmpty(patient.WxOpenId))
            {
                return OutputBase.Fail("此患者已绑定微信");
            }

            patient.WxOpenId = input.OpenId;
            patient.UpdateTime = DateTime.Now;
            return _unitWork.Commit() ? OutputBase.Success("绑定成功") : OutputBase.Fail("绑定失败");
        }
        
        /// <summary>
        /// 根据身份证号码获取患者
        /// </summary>
        /// <param name="idNo">身份证号码</param>
        /// <returns></returns>
        public async Task<GetPatientByIdNoOutput> GetByIdNo(string idNo)
        {
            var result = await _repository.GetByIdNo(idNo);
            if (result == null)
                return null;
            return Mapper.Map<Patient, GetPatientByIdNoOutput>(result);
        }
    }
}
