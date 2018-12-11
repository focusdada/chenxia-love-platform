using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAdmin
{
    public class PatientViewDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// 用户状态Css
        /// </summary>
        public string UserStatusCss { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Brithdate { get; set; }
    }
}
