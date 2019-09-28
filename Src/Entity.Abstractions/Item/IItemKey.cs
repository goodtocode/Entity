
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IItemKey
    {
        /// <summary>
        /// Item Key
        /// </summary>
        Guid ItemKey { get; set; }
    }
}
