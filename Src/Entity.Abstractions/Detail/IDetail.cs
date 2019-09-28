
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Detail
{
    /// <summary>
    /// Detail of an event, like parking, tickets, etc.
    /// </summary>    
    public interface IDetail : IDetailTypeKey, INameDescription
    {
        /// <summary>
        /// Detail data, typically text describing the detail type classification
        /// </summary>
        string DetailData { get; }
    }
}
