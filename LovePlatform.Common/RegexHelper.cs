using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LovePlatform.Common
{
    public static class RegexHelper
    {
        #region 正则判断
        /// <summary>
        /// 获取用于判断正浮点数的正则表达式(包含0) 
        /// </summary>
        public const string InculudeZeroDecimalRegex = @"^\d+(\.\d+)?$";

        /// <summary>
        /// 获取用于判断正浮点数的正则表达式(包含0) 
        /// </summary>
        public const string DecimalRegex = @"^-?\d+(\.\d+)?$";

        /// <summary>
        /// 获取用于判断正浮点数的正则表达式(不包含0)
        /// </summary>
        public const string NotInculudeZeroDecimalRegex = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>
        /// 获取用于判断非负整数的正则表达式(包含0)
        /// </summary>
        public const string InculudeZeroIntRegex = @"^\d+$";

        /// <summary>
        /// 获取用于判断整数0-9的正则表达式
        /// </summary>
        public const string DigitRegex = @"^\d{1}$";

        /// <summary>
        /// 获取用于判断>=-1 的浮点数正则表达式(包含0) 
        /// </summary>
        public const string GreaterThanOrEqual_1ToRegex = @"^(\d+(\.\d+)?)|(-1)$";

        /// <summary>
        /// 获取用于判断整数的正则表达式(包含0)
        /// </summary>
        public const string NumRegex = @"^-?[1-9]\d*|0$";

        /// <summary>
        /// 获取用于判断非负整数的正则表达式(不包含0)
        /// </summary>
        public const string NotInculudeZeroIntRegex = @"^[1-9][0-9]*$";

        /// <summary>
        /// 获取用于判断身份证的正则表达式
        /// </summary>
        public const string IdentificationCardRegex = @"(^\d{15}$)|(^\d{17}(?:\d|x|X)$)";

        /// <summary>
        /// 获取用于判断年份的正则表达式
        /// </summary>
        public const string CheckYearRegex = @"^19\d\d|20\d\d$";

        /// <summary>
        /// 获取用于判断月份的正则表达式
        /// </summary>
        public const string CheckMonthRegex = @"^(0?[1-9]|1[0-2])$";

        /// <summary>
        /// 获取用于判断日的正则表达式
        /// </summary>
        public const string CheckDayRegex = @"^((0?[1-9])|((1|2)[0-9])|30|31)$";

        /// <summary>
        /// 获取用于判断传真的正则表达式
        /// </summary>
        public const string CheckFax = @"^((\+?[0-9]{2,4}\-[0-9]{3,4}\-)|([0-9]{3,4}\-))?([0-9]{7,8})(\-[0-9]+)?$";

        /// <summary>
        /// 获取用于判断邮编的正则表达式
        /// </summary>
        public const string CheckZipCode = @"^\d{6}$";

        /// <summary>
        /// 获取用于判断邮箱的正则表达式
        /// </summary>
        public const string CheckEmailRegex = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";

        /// <summary>
        /// 获取用于判断QQ的正则表达式
        /// </summary>
        public const string CheckQqRegex = @"^\d{5,10}$";

        /// <summary>
        /// 获取用于判断手机号码的正则表达式
        /// </summary>
        public const string CheckMobileRegex = @"^1([34578]\d{9})$";
        /// <summary>
        /// 获取用于判断电话号码的正则表达式
        /// </summary>
        public const string CheckPhoneRegex = @"^(\+86\s{1,1})?((\d{3,4}\-)\d{7,8})$";

        /// <summary>
        /// 固定电话正则表达式 3-4位区号，7-8位直播号码，1－4位分机号
        /// </summary>
        public const string LandlinesRegex = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$";
        /// <summary>
        /// 获取用于判断邮政编码的正则表达式
        /// </summary>
        public const string CheckPostCode = @"^[1-9]\d{5}(?!\d)$";
        /// <summary>
        /// 反推参数正则表达式
        /// </summary>
        public const string CheckParaRegex = @"^[@].*$";

        /// <summary>
        /// 判断验证的Ip的正则表达式
        /// </summary>
        public const string CheckIp = @"^((0[0-9]|1[0-9]\d{1,2})|(2[0-5][0-5])|(2[0-4][0-9])|(\d{1,2}))\.((0[0-9]|1[0-9]\d{1,2})|(2[0-5][0-5])|(2[0-4][0-9])|(\d{1,2}))\.((0[0-9]|1[0-9]\d{1,2})|(2[0-4][0-9])|(2[0-5][0-5])|(\d{1,2}))\.((0[0-9]|1[0-9]\d{1,2})|(2[0-4][0-9])|(2[0-5][0-5])|(\d{1,2}))$";

        /// <summary>
        /// 判断是否全是数字
        /// </summary>
        public const string IsAllNumbers = "^[0-9]*$";
        /// <summary>
        /// 判断最后两位数是否是数字,前面可以为中文，数字，字母，下划线
        /// </summary>
        public const string IsEndNumbers = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+[0-9]{2}$";
        /// <summary>
        /// url格式是否正确
        /// </summary>
        public const string CheckUrl = @"^(http|www|ftp|)?(://)?(//w+(-//w+)*)(//.(//w+(-//w+)*))*((://d+)?)(/(//w+(-//w+)*))*(//.?(//w)*)(//?)?(((//w*%)*(//w*//?)*(//w*:)*(//w*//+)*(//w*//.)*(//w*&)*(//w*-)*(//w*=)*(//w*%)*(//w*//?)*(//w*:)*(//w*//+)*(//w*//.)*(//w*&)*(//w*-)*(//w*=)*)*(//w*)*)$";

        /// <summary>
        /// 日期正则表达式 年份0001-9999，格式yyyy-MM-dd或yyyy-M-d，连字符可以没有或是“-”、“/”、“.”之一
        /// </summary>
        public const string CheckDate =
            @"^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2\2(?:29))$";

        /// <summary>
        /// 日期正则表达式 年份0001-9999，
        /// 格式yyyy-MM-dd或yyyy-M-d，
        /// 连字符可以没有或是“-”、“/”、“.”之一
        /// (允许为空 )
        /// </summary>
        public const string CheckDate_EmptyAllowed =
            @"^(\s*)|(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2\2(?:29))$";

        /// <summary>
        /// 经度正则表达式 整数.小数 整数部分为-180~180的整数 小数部分为5位以内的正数
        /// </summary>
        public const string CheckLongitude = @"^[+-]?((([0-9]|[1-9][0-9]|1[0-7][0-9])(\.[0-9]+)?)|(180(\.[0]+)?))$";

        /// <summary>
        /// 纬度正则表达式 整数.小数 整数部分为-90~90的整数 小数部分为5位以内的正数
        /// </summary>
        public const string CheckLatitude = @"^[+-]?((([0-9]|[1-8][0-9])(\.[0-9]+)?)|(90(\.[0]+)?))$";

        /// <summary>
        ///只能输入英文的正则
        /// </summary>
        public const string CheckEnglish = @"^[a-zA-Z]+$";

        /// <summary>
        /// 密码强度，不能单独使用字母、数字或符号且长度为6至12位
        /// </summary>
        public const string CheckPasswordStrong = @"^((?=.*?\d)(?=.*?[A-Za-z])|(?=.*?\d)(?=.*?[!@#$%^&*])|(?=.*?[A-Za-z])(?=.*?[!@#$%^&*]))[\dA-Za-z!@#$%^&*]{6,20}$";

        /// <summary>
        /// 几时几分的正则
        /// </summary>
        public const string CheckTime = @"^[012]\d:[0-6]\d$";

        /// <summary>
        /// 检查姓名，只能是数字、字母、汉字组合或单独数字（字母、汉字）
        /// </summary>
        public const string CheckName = @"^([0-9]|[A-Za-z]|[\u4E00-\u9FA5])+$";
        #endregion

        /// <summary>
        /// 检查是否是中文
        /// </summary>
        public const string CheckChinese = @"^[\u4e00-\u9fa5]+$";

        #region 正则表达式验证
        /// <summary>
        /// 正式表达式验证
        /// </summary>
        /// <param name="cValue">验证字符</param>
        /// <param name="cStr">正式表达式</param>
        /// <returns>符合true不符合false</returns>
        public static bool CheckRegEx(string cValue, string cStr)
        {
            var objAlphaPatt = new Regex(cStr, RegexOptions.Compiled);
            return objAlphaPatt.Match(cValue).Success;
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="strMobile">待测试手机号字符串</param>
        /// <returns>是手机格式就返回true;否则返回false</returns>
        public static bool CheckMobile(string strMobile)
        {
            return strMobile != null && Regex.IsMatch(strMobile.Trim(), CheckMobileRegex);
        }

        #endregion
    }
}
