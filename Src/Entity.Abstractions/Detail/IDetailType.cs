
using System;

namespace GoodToCode.Entity.Detail
{
    /// <summary>
    /// Detail of an event, like parking, tickets, etc.
    /// </summary>
    
    public interface IDetailTypeKey
    {
        /// <summary>
        /// DetailType
        /// </summary>
        Guid DetailTypeKey { get; set; }
    }
}
