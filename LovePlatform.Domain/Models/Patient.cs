using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LovePlatform.Domain.Models
{
    /// <summary>
    /// 患者
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [StringLength(8)]
        public string CertType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [StringLength(32)]
        public string CertNo { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PatientName { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        [StringLength(200)]
        public string PatientFace { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        [StringLength(18)]
        public string IDNo { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Brithdate { get; set; }

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

        /// <summary>
        /// 体重
        /// </summary>
        public virtual ICollection<Weight> Weights { get; set; }
        
        /// <summary>
        /// 微信公众OpenId
        /// </summary>
        [StringLength(50)]
        public string WxOpenId { get; set; }
    }
}
