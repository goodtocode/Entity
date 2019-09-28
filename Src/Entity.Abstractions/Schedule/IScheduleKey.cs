
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRange + Location
    /// </summary>
    
    public interface IScheduleKey
    {
        /// <summary>
        /// Key of a schedule
        /// </summary>
        Guid ScheduleKey { get; set; }
    }
}
