using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LovePlatform.Domain.Models
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Administrator
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsSuperManager { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        [StringLength(200)]
        public string UserDesc { get; set; }

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
