
using System;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person record
    /// </summary>
    public interface IPersonKey
    {
        /// <summary>
        /// PersonKey
        /// </summary>
        Guid PersonKey { get; set; }
    }
}
