using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    public class WeightDto
    {
        public long Id { get; set; }

        /// <summary>
        /// 测量类型
        /// </summary>
        public string MeasureType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        public string MeasureTime { get; set; }
    }
}
