using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Repository
{
    public interface IUnitWork
    {
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}
