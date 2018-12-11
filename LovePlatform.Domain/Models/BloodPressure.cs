using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    /// <summary>
    /// 血压
    /// </summary>
    public partial class BloodPressure
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        public int SystolicPressure { get; set; }

        /// <summary>
        /// 收缩压是否正常
        /// </summary>
        public bool SystolicPressureIsNormal { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        public int DiastolicPressure { get; set; }

        /// <summary>
        /// 舒张压是否正常
        /// </summary>
        public bool DiastolicPressureIsNormal { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        public int HeartRate { get; set; }

        /// <summary>
        /// 心率是否正常
        /// </summary>
        public bool HeartRateIsNormal { get; set; }

        /// <summary>
        /// 数据来源（1：微信录入，2：后台录入，3：医护端录入）
        /// </summary>
        public int DataSource { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
