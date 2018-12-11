using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LovePlatform.Common.Enum
{
    public enum DiseasesTypeEnum
    {
        /// <summary>
        /// 急性髓细胞白血病（M0，M1，M2，M4，M5，M6，M7）
        /// </summary>
        [Display(Description = "急性髓细胞白血病（M0，M1，M2，M4，M5，M6，M7）")]
        JX_SXB_BXB = 0,

        /// <summary>
        /// 急性早幼粒细胞白血病（M3）
        /// </summary>
        [Display(Description = "急性早幼粒细胞白血病（M3）")]
        JX_ZYLXB_BXB = 1,

        /// <summary>
        /// 急性B淋巴细胞白血病
        /// </summary>
        [Display(Description = "急性B淋巴细胞白血病")]
        JX_BLBXB_BXB = 2,

        /// <summary>
        /// 急性T淋巴细胞白血病
        /// </summary>
        [Display(Description = "急性T淋巴细胞白血病")]
        JX_TLBXB_BXB = 3,

        /// <summary>
        /// 急性混合细胞表型白血病
        /// </summary>
        [Display(Description = "急性混合细胞表型白血病")]
        JX_HHXBBX_BXB = 4,

        /// <summary>
        /// 髓细胞肉瘤
        /// </summary>
        [Display(Description = "髓细胞肉瘤")]
        SXBRBL = 5,

        /// <summary>
        /// 骨髓增生异常综合征
        /// </summary>
        [Display(Description = "骨髓增生异常综合征")]
        GSZSYCZHZ = 6,

        /// <summary>
        /// 慢性粒细胞白血病
        /// </summary>
        [Display(Description = "慢性粒细胞白血病")]
        MXLXBBXB = 7,

        /// <summary>
        /// 真性红细胞增多症
        /// </summary>
        [Display(Description = "真性红细胞增多症")]
        ZXHXBZDZ = 8,

        /// <summary>
        /// 原发性血小板增多症
        /// </summary>
        [Display(Description = "原发性血小板增多症")]
        YFXXXBZDZ = 9,

        /// <summary>
        /// 原发性骨髓纤维化
        /// </summary>
        [Display(Description = "原发性骨髓纤维化")]
        YFXGSZWH = 10,

        /// <summary>
        /// 慢性粒单核细胞白血病
        /// </summary>
        [Display(Description = "慢性粒单核细胞白血病")]
        MXLDHXBBXB = 11,

        /// <summary>
        /// 骨髓增生异常综合征/骨髓增殖性肿瘤
        /// </summary>
        [Display(Description = "骨髓增生异常综合征/骨髓增殖性肿瘤")]
        GSZSYCZHZ_GSZSXZL = 12,

        /// <summary>
        /// 慢性淋巴细胞白血病
        /// </summary>
        [Display(Description = "慢性淋巴细胞白血病")]
        MXLBXBBXB = 13,

        /// <summary>
        /// 非霍奇金淋巴瘤
        /// </summary>
        [Display(Description = "非霍奇金淋巴瘤")]
        FHQJLBL = 14,

        /// <summary>
        /// 霍奇金淋巴瘤
        /// </summary>
        [Display(Description = "霍奇金淋巴瘤")]
        HQJLBL = 15,

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Description = "其他")]
        QT = 15
    }
}
