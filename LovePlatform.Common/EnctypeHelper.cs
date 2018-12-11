using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LovePlatform.Common
{
    public static class EnctypeHelper
    {
        /// <summary>
        /// 获取加密后的字符串
        /// </summary>
        /// <param name="originalStr">原字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string GetEncryptedStr(string originalStr)
        {
            if (!string.IsNullOrEmpty(originalStr) && originalStr.Trim() != string.Empty)
            {
                using (var hashMD5 = MD5.Create())
                {
                    return BitConverter.ToString(hashMD5.ComputeHash(Encoding.UTF8.GetBytes(originalStr))).Replace("-", "").ToUpper();
                }
            }
            else
            {
                //如果为空，返回空字符串
                return string.Empty;
            }
        }
    }
}
