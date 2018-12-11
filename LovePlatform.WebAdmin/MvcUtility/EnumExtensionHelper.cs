using LovePlatform.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.WebAdmin.MvcUtility
{
    public static class EnumExtensionHelper
    {
        
        /// <summary>
        /// 枚举转化为SelectList
        /// </summary>
        /// <typeparam name="TEnum">需要转化的枚举类型</typeparam>
        /// <param name="isAddDefaultText">是否添加默认文本（默认文本：全部）</param>
        /// <returns>转化后的SelectList</returns>
        public static List<SelectListItem> EnumToSelectList<TEnum>(bool isAddDefaultText)
        {
            var selectList = new List<SelectListItem>();
            EnumHelper.EnumToArrayList<TEnum>(isAddDefaultText).ForEach(x => selectList.Add(new SelectListItem() {
                Text = x.Text,
                Value = x.Value
            }));
            //var selectList = new SelectList(EnumHelper.EnumToArrayList<TEnum>(isAddDefaultText), "value", "text");
            return selectList;
        }
    }
}
