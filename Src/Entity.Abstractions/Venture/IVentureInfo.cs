
using System;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IVentureInfo : IVentureKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string VentureName { get; set; }

        /// <summary>
        /// VentureDescription
        /// </summary>
        string VentureDescription { get; set; }
    }
}
