
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// Business record
    /// </summary>
    public interface IBusinessInfo : IBusinessKey
    {
        /// <summary>
        /// TaxNumber
        /// </summary>
        string BusinessName { get; }

        /// <summary>
        /// TaxNumber
        /// </summary>
        string TaxNumber { get; set; }
    }
}
