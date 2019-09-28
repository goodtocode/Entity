using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ITimeBehavior
    {
        /// <summary>
        /// TimeBehavior -1 Negative, 0 Neutral, 1 Positive
        /// </summary>
        int TimeBehavior { get; set; }
    }
}
