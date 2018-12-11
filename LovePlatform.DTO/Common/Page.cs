using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.Common
{
    public class Page<T>
    {
        /// <summary>
        /// 当前页(默认值为1)
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// 每页记录数（默认值为10）
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get { return (TotalRecords + PageSize - 1) / PageSize; }
        }

        /// <summary>
        /// 记录集
        /// </summary>
        public IList<T> Items { get; set; }
    }
}