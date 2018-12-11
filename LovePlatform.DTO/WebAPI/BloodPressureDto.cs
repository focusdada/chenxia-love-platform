using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    /// <summary>
    /// 血压Dto
    /// </summary>
    public class BloodPressureDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

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
        /// 是否医生录入
        /// </summary>
        public bool IsDoctorInput { get; set; }

        /// <summary>
        /// 检测结果是否正常
        /// </summary>
        public bool MeasureResultIsNormal { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
