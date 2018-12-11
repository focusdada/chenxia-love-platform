using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Common
{
    public static class ExtensionHelper
    {
        /// <summary>
        /// Datetime to string with format : yyyy-MM-dd
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToShortDateFormatString(this DateTime datetime)
        {
            return datetime.ToString(CommConstant.ShortDateFormatString);
        }

        /// <summary>
        /// Datetime to string with format : yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateTimeFormatString(this DateTime datetime)
        {
            return datetime.ToString(CommConstant.DateTimeFormatString);
        }

        
    }
}
