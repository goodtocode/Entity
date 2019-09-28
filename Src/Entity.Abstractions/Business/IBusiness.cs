
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// Business record
    /// </summary>
    public interface IBusiness : IName
    {
        /// <summary>
        /// TaxNumber
        /// </summary>
        string TaxNumber { get; set; }
    }
}
