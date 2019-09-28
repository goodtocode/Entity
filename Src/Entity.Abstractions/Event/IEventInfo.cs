
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IEventInfo : IEventKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// EventDescription
        /// </summary>
        string EventDescription { get; set; }
    }
}
