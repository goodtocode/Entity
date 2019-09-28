
using System;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IOptionKey
    {
        /// <summary>
        /// Option Key
        /// </summary>
        Guid OptionKey { get; set; }
    }
}
