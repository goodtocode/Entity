
using System;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ILocationId
    {
        /// <summary>
        /// LocationId
        /// </summary>
        int LocationId { get; set; }
    }
}
