using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    /// <summary>
    /// 患者搜索输入
    /// </summary>
    public class PatientSearchInput : SearchBase
    {
        /// <summary>
        /// 患者名称
        /// </summary>
        public string PatientName { get; set; }
    }
}