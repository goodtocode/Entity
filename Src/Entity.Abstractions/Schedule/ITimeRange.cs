
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// TimeRange for a schedule. Schedule = Resource + TimeRange + Location
    /// </summary>    
    public interface ITimeRange
    {
        /// <summary>
        /// BeginDate
        /// </summary>
        DateTime BeginDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime EndDate { get; set; }
    }
}
