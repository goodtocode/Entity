
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IItem : INameDescription
    {
        /// <summary>
        /// Type of item, for filtering and behavior
        /// </summary>
        Guid ItemTypeKey { get; set; }
    }
}
