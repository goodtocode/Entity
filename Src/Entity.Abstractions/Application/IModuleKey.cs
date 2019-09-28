
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Module
    /// </summary>        
    public interface IModuleKey
    {
        /// <summary>
        /// ModuleId
        /// </summary>
        Guid ModuleKey { get; set; }
    }
}
