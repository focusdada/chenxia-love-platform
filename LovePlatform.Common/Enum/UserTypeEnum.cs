using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.Common.Enum
{
    public enum UserTypeEnum
    {
        /// <summary>
        /// 患者
        /// </summary>
        [Display(Description = "患者")]
        Patient = 0,

        /// <summary>
        /// 家属
        /// </summary>
        [Display(Description = "家属")]
        FamilyMember = 1
    }
}
