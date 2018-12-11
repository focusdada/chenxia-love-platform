using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string WexinOpenId { get; set; }

        /// <summary>
        /// 用户类型 0:患者 1:家属
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [StringLength(200)]
        public string BirthPlace { get; set; }

        /// <summary>
        /// 居住地
        /// </summary>
        [StringLength(200)]
        public string ResidentialPlace { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [StringLength(20)]
        public string Contact { get; set; }

        /// <summary>
        /// 备用联系方式
        /// </summary>
        [StringLength(20)]
        public string ContactReserve { get; set; }

        /// <summary>
        /// 备用联系方式
        /// </summary>
        [StringLength(20)]
        public string ContactReserve1 { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(200)]
        public string Avatar { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int State { get; set; }

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
