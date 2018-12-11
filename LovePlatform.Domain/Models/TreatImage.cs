using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    public class TreatImage
    {
        /// <summary>
        /// 治疗图片Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 治疗Id
        /// </summary>
        public int TreatId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    
        /// <summary>
        /// 图像地址
        /// </summary>
        [StringLength(200)]
        public string ImagePath { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UploadTime { get; set; }
    }
}
