using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    /// <summary>
    /// 患者详情
    /// </summary>
    public class PatientDto : PatientBaseDto
    {
        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Brithdate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否有体重数据
        /// </summary>
        public bool HasWeightData { get; set; }
    }
}
