using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LovePlatform.Common
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns>枚举的描述</returns>
        public static string GetDescription<TEnum>(TEnum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? "Description Not Found";
        }

        /// <summary>
        /// 枚举转化为List<OptionItem>
        /// </summary>
        /// <typeparam name="TEnum">需要转化的枚举类型</typeparam>
        /// <param name="isAddDefaultText">是否添加默认文本（默认文本：全部）</param>
        /// <returns>转化后的ArrayList</returns>
        public static List<OptionItem> EnumToArrayList<TEnum>(bool isAddDefaultText)
        {
            return EnumToArrayList<TEnum>(isAddDefaultText, "全部");
        }

        /// <summary>
        /// 枚举转化为ArrayList
        /// </summary>
        /// <typeparam name="TEnum">需要转化的枚举类型</typeparam>
        /// <param name="isAddDefaultText">是否添加默认文本</param>
        /// <param name="selectDefaultText">select默认的文本</param>
        /// <returns>转化后的ArrayList</returns>
        public static List<OptionItem> EnumToArrayList<TEnum>(bool isAddDefaultText, string selectDefaultText)
        {
            List<OptionItem> tempList = new List<OptionItem>();

            if (isAddDefaultText)
            {
                tempList.Add(new OptionItem()
                {
                    Value = "",
                    Text = selectDefaultText
                });
            }

            IEnumerable<TEnum> items = System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            foreach (var item in items)
            {
                tempList.Add(new OptionItem()
                {
                    Value = Convert.ToInt32(item).ToString(),
                    Text = GetDescription(item)
                });
            }
            return tempList;
        }
    }

    public class OptionItem
    {
        public string Value { get; set; }

        public string Text { get; set; }
    }
}
