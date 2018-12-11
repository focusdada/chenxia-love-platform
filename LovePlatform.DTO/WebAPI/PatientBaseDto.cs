using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    /// <summary>
    /// 患者输出
    /// </summary>
    public class PatientBaseDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 患者姓名拼音码
        /// </summary>
        public string PinyinCode { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public string PatientFace { get; set; }
    }
}
