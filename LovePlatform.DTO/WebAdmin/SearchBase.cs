using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    /// <summary>
    /// 搜索基类
    /// </summary>
    public class SearchBase
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 分页页号（从1开始）
        /// </summary>
        public int PageIndex { get; set; } = 1;
    }
}
