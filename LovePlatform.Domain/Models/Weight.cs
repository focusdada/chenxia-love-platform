using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    public class Weight
    {
        /// <summary>
        /// 体重Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime MeasureTime { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
