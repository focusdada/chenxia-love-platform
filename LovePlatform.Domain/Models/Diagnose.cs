using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    public class Diagnose
    {
        /// <summary>
        /// 诊断ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 疾病类型
        /// </summary>
        public int DiseasesType { get; set; }

        /// <summary>
        /// 染色体
        /// </summary>
        [StringLength(500)]
        public string Chromosomal { get; set; }

        /// <summary>
        /// 免疫分型
        /// </summary>
        [StringLength(500)]
        public string Immunophenotyping { get; set; }

        /// <summary>
        /// 融合基因
        /// </summary>
        [StringLength(500)]
        public string FusionGene { get; set; }

        /// <summary>
        /// 二代基因测序
        /// </summary>
        [StringLength(500)]
        public string SecondGenerationGeneSequencing { get; set; }

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
