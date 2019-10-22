
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// SlotAggregate
    /// </summary>
    public sealed class SlotAggregate : SlotInfo
    {
        /// <summary>
        /// Locations for this slot
        /// </summary>
        public IEnumerable<SlotLocation> Locations { get; internal set; }

        /// <summary>
        /// Resources for this slot
        /// </summary>
        public IEnumerable<SlotResource> Resources { get; internal set; }

        /// <summary>
        /// Times for this slot
        /// </summary>
        public IEnumerable<SlotTimeRange> TimeRanges { get; internal set; }

        /// <summary>
        /// Recurring times for this slot
        /// </summary>
        public IEnumerable<SlotTimeRecurring> TimeReocurring { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotAggregate() : base() { }

        /// <summary>
        /// Load by schedule
        /// </summary>
        /// <param name="scheduleKey"></param>
        /// <returns></returns>
        public static IEnumerable<SlotAggregate> GetBySchedule(Guid scheduleKey)
        {
            var returnValue = new List<SlotAggregate>();
            var slots = new EntityReader<ScheduleSlot>().GetByWhere(x => x.ScheduleKey == scheduleKey).ToList();
            slots.ForEach(x => returnValue.Add(SlotAggregate.GetByKey(x.SlotKey)));
            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slotKey"></param>
        /// <returns></returns>
        public new static SlotAggregate GetByKey(Guid slotKey)
        {
            var returnValue = GetByKey(slotKey);
            returnValue.Locations = SlotLocation.GetByWhere(x => x.Key == slotKey);
            returnValue.Resources = SlotResource.GetByWhere(x => x.Key == slotKey);
            returnValue.TimeRanges = SlotTimeRange.GetByWhere(x => x.Key == slotKey);
            returnValue.TimeReocurring = SlotTimeRecurring.GetByWhere(x => x.Key == slotKey);

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeToCheck"></param>
        /// <returns></returns>
        public bool HasPositiveTime(DateTime timeToCheck)
        {
            var returnValue = Defaults.Boolean;

            returnValue = returnValue && MatchingRange(timeToCheck).Any();
            returnValue = returnValue && MatchingDateTime(timeToCheck).Any();
            returnValue = returnValue && MatchingRecurring(timeToCheck).Any();

            return returnValue;
        }

        /// <summary>
        /// Find matching ranges that contain timeToCheck
        /// </summary>
        /// <param name="timeToCheck"></param>
        /// <returns></returns>
        public IEnumerable<SlotTimeRange> MatchingRange(DateTime timeToCheck)
        {
            var returnValue = new List<SlotTimeRange>();
            returnValue.AddRange(TimeRanges.Where(x => x.BeginDate <= timeToCheck && x.EndDate >= timeToCheck));
            return returnValue;
        }

        /// <summary>
        /// Times that are recurring matches
        /// </summary>
        /// <param name="timeToCheck"></param>
        /// <returns></returns>
        public IEnumerable<DateTime> MatchingDateTime(DateTime timeToCheck)
        {
            var returnValue = new List<DateTime>();

            //
            // Recurring:Monthly Day of Week (7: 0-6)
            // I.e. Every 3 Tuesday (position, dayofweek)
            //
            var dayNumberOfMonth = GetDayOfWeekPosition(timeToCheck);
            var datesForDayNumber = GetDaysOfWeekInMonth(dayNumberOfMonth, timeToCheck);
            returnValue.AddRange(datesForDayNumber
                .Where(x => x.TimeOfDay <= timeToCheck.TimeOfDay && x.TimeOfDay >= timeToCheck.TimeOfDay));
            return returnValue;
        }

        /// <summary>
        /// Times that are recurring matches
        /// </summary>
        /// <param name="timeToCheck"></param>
        /// <returns></returns>
        public IEnumerable<SlotTimeRecurring> MatchingRecurring(DateTime timeToCheck)
        {
            var returnValue = new List<SlotTimeRecurring>();

            // Reoccurring Times
            var availableRecurring = TimeReocurring.Where(x => x.TimeBehavior == TimeBehaviors.AddTime.Key);

            //
            // Daily (N/A)
            //  Time-check only. Is valid for every day.
            //
            returnValue.AddRange(availableRecurring
                .Where(x => x.TimeCycleKey == TimeCycles.Daily.Key)
                .Where(x => x.BeginTime.TimeOfDay <= timeToCheck.TimeOfDay && x.EndTime.TimeOfDay >= timeToCheck.TimeOfDay));

            //
            // Weekly (7: 0-6)
            //
            returnValue.AddRange(availableRecurring
                .Where(x => x.TimeCycleKey == TimeCycles.WeeklyDay.Key)
                .Where(x => x.BeginTime.TimeOfDay <= timeToCheck.TimeOfDay && x.EndTime.TimeOfDay >= timeToCheck.TimeOfDay)
                .Where(y => y.BeginDay <= (int)timeToCheck.DayOfWeek && y.EndDay >= (int)timeToCheck.DayOfWeek));

            //
            // Monthly (31: 0-30)
            //
            returnValue.AddRange(availableRecurring
                .Where(x => x.TimeCycleKey == TimeCycles.MonthDay.Key)
                .Where(x => x.BeginTime.TimeOfDay <= timeToCheck.TimeOfDay && x.EndTime.TimeOfDay >= timeToCheck.TimeOfDay)
                .Where(y => y.BeginDay <= (int)timeToCheck.Day && y.EndDay >= (int)timeToCheck.Day));

            //
            // Yearly (365: 0-364)
            //
            returnValue.AddRange(availableRecurring.Where(x => x.TimeCycleKey == TimeCycles.YearlyDay.Key)
                .Where(x => x.BeginTime.TimeOfDay <= timeToCheck.TimeOfDay && x.EndTime.TimeOfDay >= timeToCheck.TimeOfDay)
                .Where(y => y.BeginDay <= (int)timeToCheck.DayOfYear && y.EndDay >= (int)timeToCheck.DayOfYear));

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeToCheck"></param>
        /// <returns></returns>
        public bool HasNegativeTime(DateTime timeToCheck)
        {
            return false;
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }

        private IEnumerable<DateTime> GetDatesForYear(int year)
        {
            return GetDates(new DateTime(year, 1, 1), new DateTime(year, 12, 31));
        }

        private IEnumerable<DateTime> GetDates(DateTime startDate, DateTime endDate)
        {
            var returnValue = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                                  .Select(x => startDate.AddDays(x));
            return returnValue;
        }

        private IEnumerable<DateTime> GetDaysOfWeekInMonth(DateTime dateForDayAndMonth)
        {
            return GetDaysOfWeekInMonth(dateForDayAndMonth.DayOfWeek, dateForDayAndMonth);
        }

        private IEnumerable<DateTime> GetDaysOfWeekInMonth(DayOfWeek day, DateTime monthToCheck)
        {
            var returnValue = GetDates(monthToCheck.FirstDayOfMonth(), monthToCheck.LastDayOfMonth())
                                .Where(x => x.DayOfWeek == day);
            return returnValue;
        }

        private DayOfWeek GetDayOfWeekPosition(DateTime dateToGetPosition)
        {
            var dates = GetDaysOfWeekInMonth(dateToGetPosition)
                .Where(currRow => currRow.Date == dateToGetPosition)
                .OrderBy(currRow => currRow.Day)
                .Select((currRow, index) => new { Row = currRow, Index = index + 1 });
            return (DayOfWeek)dates.Where(x => x.Row.Date == dateToGetPosition).Select(x => x.Index).FirstOrDefault();
        }
    }
}