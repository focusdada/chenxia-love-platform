using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Output
{
    /// <summary>
    /// PatientLoginOutput
    /// </summary>
    public class PatientLoginOutput
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public string PatientFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Brithdate { get; set; }
    }
}
