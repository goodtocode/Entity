
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// TimeRecurring for an entity (location or resource)
    /// </summary>    
    public interface ITimeRecurring
    {
        /// <summary>
        /// BeginDay
        /// </summary>
        int BeginDay { get; set; }

        /// <summary>
        /// EndDay
        /// </summary>
        int EndDay { get; set; }

        /// <summary>
        /// BeginTime
        /// </summary>
        DateTime BeginTime { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// Interval of recurring. Most are "all intervals". Some may be every nth interval.
        /// </summary>
        int Interval { get; set; }
    }
}
