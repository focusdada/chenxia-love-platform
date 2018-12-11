using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// Add Treat DTO
    /// </summary>
    public class AddTreatDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 治疗时间
        /// </summary>
        public string TreatDate { get; set; }

        /// <summary>
        /// Treate Doctor
        /// </summary>
        public string TreatDoctor { get; set; }

        /// <summary>
        /// 治疗地点
        /// </summary>
        public string TreatPlace { get; set; }

        /// <summary>
        /// 治疗经过
        /// </summary>
        public string TreateDetail { get; set; }

        /// <summary>
        /// 资料图片
        /// </summary>
        public string TreatePic1 { get; set; }
    }
}
