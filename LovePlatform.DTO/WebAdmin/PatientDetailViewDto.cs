using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    public class PatientDetailViewDto : PatientViewDto
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicalInsuranceType { get; set; }

        /// <summary>
        /// 首次透析日期
        /// </summary>
        public string FirstDialysisDate { get; set; }

        /// <summary>
        /// 死亡日期
        /// </summary>
        public string DateOfDeath { get; set; }

        /// <summary>
        /// 治疗状态
        /// </summary>
        public string TherapyStatus { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public string PatientFace { get; set; }
    }
}
