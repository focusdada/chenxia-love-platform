using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    public class Treat
    {
        /// <summary>
        /// 治疗Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 治疗时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public string TreatDate { get; set; }

        [StringLength(50)]
        public string TreatDoctor { get; set; }

        /// <summary>
        /// 治疗地点
        /// </summary>
        [StringLength(200)]
        public string TreatPlace { get; set; }

        /// <summary>
        /// 治疗经过
        /// </summary>
        [StringLength(200)]
        public string TreateDetail { get; set; }

        /// <summary>
        /// 治疗图片
        /// </summary>
        [StringLength(200)]
        public string TreatePic1 { get; set; }


        /// <summary>
        /// 治疗图片
        /// </summary>
        [StringLength(200)]
        public string TreatePic2 { get; set; }


        /// <summary>
        /// 治疗图片
        /// </summary>
        [StringLength(200)]
        public string TreatePic3 { get; set; }


        /// <summary>
        /// 治疗图片
        /// </summary>
        [StringLength(200)]
        public string TreatePic4 { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }
    }
}
