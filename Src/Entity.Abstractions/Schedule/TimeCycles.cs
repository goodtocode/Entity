
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Cycles of time for reoccurrance
    /// </summary>
    public struct TimeCycles
    {
        /// <summary>
        ///  Daily
        ///     At Time
        /// </summary>
        public static KeyValuePair<Guid, int> Daily { get; } = new KeyValuePair<Guid, int>(new Guid("00000000-0000-0000-0000-000000000000"), 1);

        /// <summary>
        ///  Weekdays
        ///     Day 1-5 at time
        /// </summary>
        public static KeyValuePair<Guid, int> Weekdays { get; } = new KeyValuePair<Guid, int>(new Guid("B55CDC94-F9B6-4A45-BA46-13574AB35FF4"), 5);

        /// <summary>
        ///  Weekends
        ///    Day 0 or 6 at time
        /// </summary>
        public static KeyValuePair<Guid, int> Weekends { get; } = new KeyValuePair<Guid, int>(new Guid("325F3E37-76E5-4070-8BF9-7486A2EB62D3"), 2);

        /// <summary>
        ///  DayOfWeek
        ///     I.e. Every Tuesday at 11am
        ///     Day 0-6 at time
        /// </summary>
        public static KeyValuePair<Guid, int> WeeklyDay { get; } = new KeyValuePair<Guid, int>(new Guid("F4C5AED5-4853-47E1-AA2C-A30F86F4A357"), 7);

        /// <summary>
        ///  DayOfMonth
        ///    I.e. Every 10th day of the month
        /// </summary>
        public static KeyValuePair<Guid, int> MonthDay { get; } = new KeyValuePair<Guid, int>(new Guid("28C6DE9B-600A-45DC-90AE-01CB20CD9BA8"), 31);

        /// <summary>
        ///  MonthlyWeekday
        ///    I.e. Every 3rd Tuesday at 11am
        /// </summary>
        public static KeyValuePair<Guid, int> MonthlyDayOfWeek { get; } = new KeyValuePair<Guid, int>(new Guid("07424BEE-9C82-4893-85F3-2B1F5A3E5A67"), 31);

        /// <summary>
        ///  YearlyDay
        ///    I.e. Every 100th day of year
        /// </summary>
        public static KeyValuePair<Guid, int> YearlyDay { get; } = new KeyValuePair<Guid, int>(new Guid("403E4772-655E-4129-87B3-058EDCF1E553"), 365);

        /// <summary>
        ///  YearlyDayOfWeek
        ///    Every 3rd Tuesday of the year
        /// </summary>
        public static KeyValuePair<Guid, int> YearlyDayOfWeek { get; } = new KeyValuePair<Guid, int>(new Guid("E9971F55-4715-4D23-8245-730575B74D1A"), 14);
    }
}
