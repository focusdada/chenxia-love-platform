using LovePlatform.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Repository
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitWork : IUnitWork
    {
        private readonly LovePlatformContext _context;

        public UnitWork(LovePlatformContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            _context.SaveChanges();
            return true;
        }
    }
}
