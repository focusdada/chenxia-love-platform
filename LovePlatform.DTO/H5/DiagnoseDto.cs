using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.H5
{
    /// <summary>
    /// 诊断数据
    /// </summary>
    public class DiagnoseDto
    {
        /// <summary>
        /// 诊断ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 疾病类型
        /// </summary>
        public string DiseasesType { get; set; }

        /// <summary>
        /// 染色体
        /// </summary>
        public string Chromosomal { get; set; }

        /// <summary>
        /// 免疫分型
        /// </summary>
        public string Immunophenotyping { get; set; }

        /// <summary>
        /// 融合基因
        /// </summary>
        public string FusionGene { get; set; }

        /// <summary>
        /// 二代基因测序
        /// </summary>
        public string SecondGenerationGeneSequencing { get; set; }
    }
}
