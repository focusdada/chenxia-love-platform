using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// AddWeightInput
    /// </summary>
    public class AddWeightInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 测量类型(2-透后；99-日常)
        /// </summary>
        [Required]
        public int MeasureType { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Required]
        [Range(typeof(decimal), "0.1", "999.9", ErrorMessage = "请输入正确的体重值")]
        public decimal Value { get; set; }
    }
}
