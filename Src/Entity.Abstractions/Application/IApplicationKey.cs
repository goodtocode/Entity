
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// App Id
    /// </summary>
    
    public interface IApplicationKey
    {
        /// <summary>
        /// ApplicationId
        /// </summary>
        Guid ApplicationKey { get; set; }
    }
}
