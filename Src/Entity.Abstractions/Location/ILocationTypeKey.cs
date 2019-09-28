
using System;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ILocationTypeKey
    {
        /// <summary>
        /// Location Key
        /// </summary>
        Guid LocationTypeKey { get; set; }
    }
}
