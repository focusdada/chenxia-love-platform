using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.Common.Enum
{
    /// <summary>
    /// 用户状态枚举
    /// </summary>
    public enum UserStateEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Description = "正常")]
        Enable = 0,

        /// <summary>
        /// 冻结
        /// </summary>
        [Display(Description = "冻结")]
        Disable = 1,

        /// <summary>
        /// 删除
        /// </summary>
        [Display(Description = "删除")]
        Delete = 2
    }
}
