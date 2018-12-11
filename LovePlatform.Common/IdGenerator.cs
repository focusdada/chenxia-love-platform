using Flakey;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Common
{
    /// <summary>
    /// Id生成器
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// 创建生成器
        /// </summary>
        /// <returns></returns>
        public static Flakey.IdGenerator CreateGenerator(int generatorId)
        {
            //雪花生成器
            return new Flakey.IdGenerator(generatorId, new DateTime(2017, 4, 1, 0, 0, 0, DateTimeKind.Utc), new MaskConfig(53, 2, 8));
        }
    }
}
