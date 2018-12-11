using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.Common.Enum
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum SexEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        [Display(Description = "男")]
        Male = 0,

        /// <summary>
        /// 女
        /// </summary>
        [Display(Description = "女")]
        Female = 1
    }
}
