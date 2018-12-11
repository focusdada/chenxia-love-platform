using LovePlatform.Common;
using LovePlatform.Domain;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.DTO.WebAPI.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.Repository
{
    public class PatientRepository
    {
        private readonly LovePlatformContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public PatientRepository(LovePlatformContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public long Add(Patient patient)
        {
            DateTime now = DateTime.Now;
            patient.Id = _idGenerator.CreateId();
            patient.AddTime = now;
            patient.UpdateTime = now;
            _context.Patients.Add(patient);

            return patient.Id;
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public async Task Update(Patient patient)
        {
            var entity = await _context.Patients.FindAsync(patient.Id);
            entity.UpdateTime = DateTime.Now;
            _context.Patients.Update(patient);
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public async Task UpdatePatient(Patient patient)
        {
            var entity = await _context.Patients.FindAsync(patient.Id);
            entity.Brithdate = patient.Brithdate;
            entity.PatientName = patient.PatientName;
            entity.Sex = patient.Sex;
            entity.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 删除患者
        /// </summary>
        /// <param name="id">患者id</param>
        /// <returns></returns>
        public void Delete(long id)
        {
            _context.Patients.Remove(new Patient { Id = id });
        }

        /// <summary>
        /// 获取患者
        /// </summary>
        /// <param name="dialysisPatientId">透析患者Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<Patient> Get(int id)
        {
            return await _context.Patients.Where(t => t.Id==id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据患者Id获取患者实体
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <returns>患者实体</returns>
        public async Task<Patient> GetPatientById(long id)
        {
            var patient = await _context.Patients.Where(i => i.Id == id).FirstOrDefaultAsync();

            return patient;
        }

        /// <summary>
        /// 更新体重
        /// </summary>
        /// <param name="input">更新体重输入</param>
        /// <returns></returns>
        public async Task UpdateWeight(UpdateWeightInput input)
        {
            var patient = await _context.Patients.FindAsync(input.PatientId);
            patient.Weight = input.Weight;
            patient.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 根据患者搜索输入分页获取患者实体列表
        /// </summary>
        /// <param name="input">患者搜索输入</param>
        /// <returns>患者实体列表</returns>
        public async Task<Tuple<List<Patient>, int>> GetPatientPageList(PatientSearchInput input)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(input.PatientName))
            {
                query = query.Where(i => i.PatientName.Contains(input.PatientName));
            }

            int total = query.Count();
            var patientList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Patient>, int>(patientList, total);
        }

        /// <summary>
        /// 根据OpenId获取患者
        /// </summary>
        /// <param name="openId">微信OpenId</param>
        /// <returns></returns>
        public async Task<Patient> GetByOpenId(string openId)
        {
            return await _context.Patients.Where(t => t.WxOpenId == openId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据身份证号码获取患者
        /// </summary>
        /// <param name="idNo">身份证号码</param>
        /// <returns></returns>
        public async Task<Patient> GetByIdNo(string idNo)
        {
            try
            {
                var result = await _context.Patients.Where(t => t.IDNo == idNo).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
