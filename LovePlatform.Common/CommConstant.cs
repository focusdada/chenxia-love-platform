using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Common
{
    public static class CommConstant
    {
        /// <summary>
        /// 英文逗号
        /// </summary>
        public const string Comma = ",";

        /// <summary>
        /// 初始密码
        /// </summary>
        public const string InitialPassword = "E10ADC3949BA59ABBE56E057F20F883E";

        public const string ShortDateFormatString = "yyyy-MM-dd";
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm";
        public const string TimeFormatString = "HH:mm";
        public const string FullTimeFormatString = "yyyyMMddHHmmssfff";

        #region OSS
        /// <summary>
        /// OssUrl
        /// </summary>
        public const string OssUrl = @"https://love-platform.oss-cn-shanghai.aliyuncs.com/";


        /// <summary>
        /// OssAccessKeyId
        /// </summary>
        public const string OssAccessKeyId = "LTAIH87WQnIGvLXm";

        /// <summary>
        /// OssAccessKeySecret
        /// </summary>

        public const string OssAccessKeySecret = "0vzLZH3gPPIVjwQufGNkn9ivcdfx9D";

        /// <summary>
        /// OssBucket(dialysis)
        /// </summary>
        public const string OssBucket = "love-platform";

        /// <summary>
        /// OssRegion
        /// </summary>
        public const string OssRegion = "oss-cn-shanghai";

        /// <summary>
        /// OssAvatarDir
        /// </summary>
        public const string OssAvatarDir = "avatar/";
        #endregion

        /// <summary>
        /// 后台登录当前用户
        /// </summary>
        public const string AdminLoginCurrentUser = "CurrentUser";

        /// <summary>
        /// H5平台登录用户Session Key
        /// </summary>
        public const string H5CurrentUser = "H5CurrentUser";
    }
}
