using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Input
{
    /// <summary>
    /// 更新体重
    /// </summary>
    public class UpdateWeightInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Range(15d, 140d, ErrorMessage = "请输入正常体重范围")]
        public decimal Weight { get; set; }
    }
}
