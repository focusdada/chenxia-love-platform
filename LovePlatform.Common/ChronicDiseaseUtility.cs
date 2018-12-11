using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Common
{
    /// <summary>
    /// 慢病Utility
    /// </summary>
    public class ChronicDiseaseUtility
    {
        /// <summary>
        /// 是否收缩压正常
        /// </summary>
        /// <param name="value">收缩压值（单位mmhg）</param>
        /// <returns></returns>
        public static bool IsSystolicPressureNormal(int value)
        {
            return value >= 90 && value <= 140;
        }

        /// <summary>
        /// 是否舒张压正常
        /// </summary>
        /// <param name="value">舒张压值（单位mmhg）</param>
        /// <returns></returns>
        public static bool IsDiastolicPressureNormal(int value)
        {
            return value >= 60 && value <= 90;
        }

        /// <summary>
        /// 是否心率正常
        /// </summary>
        /// <param name="value">心率值（次/分钟）</param>
        /// <returns></returns>
        public static bool IsHeartRateNormal(int value)
        {
            return value >= 60 && value <= 100;
        }

        /// <summary>
        /// 是否总胆固醇正常
        /// </summary>
        /// <param name="value">总胆固醇值（mmol/L）</param>
        /// <returns></returns>
        public static bool IsTotalCholesterolNormal(decimal value)
        {
            return value < 5.18M;
        }

        /// <summary>
        /// 是否高密度脂蛋白正常
        /// </summary>
        /// <param name="value">高密度脂蛋白值（mmol/L）</param>
        /// <returns></returns>
        public static bool IsHDLNormal(decimal value)
        {
            return value >= 1.04M && value <= 1.55M;
        }

        /// <summary>
        /// 是否低密度脂蛋白正常
        /// </summary>
        /// <param name="value">低密度脂蛋白值（mmol/L）</param>
        /// <returns></returns>
        public static bool IsLDLNormal(decimal value)
        {
            return value < 3.37M;
        }

        /// <summary>
        /// 是否甘油三脂正常
        /// </summary>
        /// <param name="value">甘油三脂值（mmol/L）</param>
        /// <returns></returns>
        public static bool IsTriglycerideNormal(decimal value)
        {
            return value < 1.7M;
        }

        /// <summary>
        /// 获取是否正常描述
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string GetIsNormalDesc(bool isNormal)
        {
            if (isNormal)
            {
                return "正常";
            }
            else
            {
                return "异常";
            }
        }
    }
}
