
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IScheduleTypeKey
    {
        /// <summary>
        /// Schedule Key
        /// </summary>
        Guid ScheduleTypeKey { get; set; }
    }
}
