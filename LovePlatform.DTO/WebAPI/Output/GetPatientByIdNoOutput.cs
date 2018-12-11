using LovePlatform.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI.Output
{
    /// <summary>
    /// GetPatientByIdNoOutput
    /// </summary>
    public class GetPatientByIdNoOutput : DictDto
    {
        /// <summary>
        /// WxOpenId
        /// </summary>
        public string WxOpenId { get; set; }
    }
}
