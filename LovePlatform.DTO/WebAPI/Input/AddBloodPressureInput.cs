using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// 添加血压请求
    /// </summary>
    public class AddBloodPressureInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Required(ErrorMessage = "请输入收缩压")]
        public int SystolicPressure { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Required(ErrorMessage = "请输入舒张压")]
        public int DiastolicPressure { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [Required(ErrorMessage = "请输入心率")]
        public int HeartRate { get; set; }

        /// <summary>
        /// 数据来源（1：微信录入，2：后台录入，3：医护端录入）
        /// </summary>
        [Range(1, 3, ErrorMessage = "请填写正确的数据来源")]
        public int DataSource { get; set; }
    }
}
