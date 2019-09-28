

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IScheduleInfo
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string ScheduleName { get; set; }

        /// <summary>
        /// ScheduleDescription
        /// </summary>
        string ScheduleDescription { get; set; }
    }
}
