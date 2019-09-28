
using System;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IResourceTypeKey
    {
        /// <summary>
        /// Resource Key
        /// </summary>
        Guid ResourceTypeKey { get; set; }
    }
}
