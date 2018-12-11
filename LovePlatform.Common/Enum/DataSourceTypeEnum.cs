using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.Common.Enum
{
    /// <summary>
    /// 慢病管理数据来源类型枚举
    /// </summary>
    public enum DataSourceTypeEnum
    {
        /// <summary>
        /// 微信录入
        /// </summary>
        [Display(Description = "微信录入")]
        WeixinInput = 1,

        /// <summary>
        /// 后台录入
        /// </summary>
        [Display(Description = "后台录入")]
        BackendInput = 2,
    }
}
