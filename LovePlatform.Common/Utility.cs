using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Common
{
    public static class Utility
    {
        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="birthDate">出生日期</param>
        /// <returns></returns>
        public static int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
            return age;
        }

        /// <summary>
        /// 获取用户状态CSS
        /// </summary>
        /// <param name="userStatus">用户状态</param>
        /// <returns></returns>
        public static string GetUserStatusCss(int userStatus)
        {
            var css = string.Empty;
            switch (userStatus)
            {
                case 0:
                    css = "default";
                    break;
                case 1:
                    css = "info";
                    break;
                case 2:
                    css = "warning";
                    break;
                case 3:
                    css = "danger";
                    break;
                case 4:
                    css = "success";
                    break;
                default:
                    break;
            }

            return css;
        }
    }
}
