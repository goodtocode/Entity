using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    [TestClass()]
    public class SlotAggregateTests
    {
        private static readonly object LockObject = new object();
        private static volatile List<Guid> _recycleBin = null;
        /// <summary>
        /// Singleton for recycle bin
        /// </summary>
        internal static List<Guid> RecycleBin
        {
            get
            {
                if (_recycleBin != null) return _recycleBin;
                lock (LockObject)
                {
                    if (_recycleBin == null)
                    {
                        _recycleBin = new List<Guid>();
                    }
                }
                return _recycleBin;
            }
        }

        List<ScheduleInfo> testSchedules = new List<ScheduleInfo>()
        {
            new ScheduleInfo() {Name = "Dr. John Schedule",  Description = "I want my baby back ribs!"},
            new ScheduleInfo() {Name = "Karate School Schedule", Description = "Meet you at the library for a tutor session."},
            new ScheduleInfo() {Name = "Empty Schedule", Description = "Nobody has to code anymore, but we cant stop anyways!"}
        };

        List<SlotTimeRange> testSlotTimeRanges = new List<SlotTimeRange>()
        {
            new SlotTimeRange() { SlotName = "AvailableDay", BeginDate = new DateTime(new DateTime().Year, 01, 01), EndDate = new DateTime(new DateTime().Year, 01, 02), TimeTypeKey = TimeTypes.Available.Item1 },
            new SlotTimeRange() { SlotName = "DayOff", BeginDate = new DateTime(new DateTime().Year, 01, 01), EndDate = new DateTime(new DateTime().Year, 01, 02), TimeTypeKey = TimeTypes.Unavailable.Item1 },
            new SlotTimeRange() { SlotName = "DayHoliday", BeginDate = new DateTime(new DateTime().Year, 01, 01), EndDate = new DateTime(new DateTime().Year, 01, 03), TimeTypeKey = TimeTypes.Holiday.Item1 },
        };

        List<SlotTimeRecurring> testSlotTimeRecurring = new List<SlotTimeRecurring>()
        {
            new SlotTimeRecurring() {SlotName = "Mondays Available",  BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0), TimeTypeKey = TimeTypes.Available.Item1 },
            new SlotTimeRecurring() {SlotName = "Tuesdays Unavailable",  BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0), TimeTypeKey = TimeTypes.Unavailable.Item1 },
            new SlotTimeRecurring() {SlotName = "Fridays Holidays", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0), TimeTypeKey = TimeTypes.Holiday.Item1 },
        };

        /// <summary>
        /// Initializes class before tests are ran
        /// </summary>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // Database is required for these tests
            var databaseAccess = false;
            var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);
            using (var connection = new SqlConnection(configuration.ConnectionStringValue("DefaultConnection")))
            {
                databaseAccess = connection.CanOpen();
            }
            Assert.IsTrue(databaseAccess);
        }

        /// <summary>
        /// Schedule_ScheduleInfo
        /// </summary>
        ///[TestMethod()]
        public void Schedule_SlotAggregate_Create()
        {
            var scheduleEntity = new ScheduleInfo();
            var slotRangeEntity = new SlotTimeRange();
            var slotRecurEntity = new SlotTimeRecurring();
            var slotRecurWriter = new StoredProcedureWriter<SlotTimeRecurring>();
            var scheduleSlotEntity = new ScheduleSlot();
            var scheduleSlotWriter = new StoredProcedureWriter<ScheduleSlot>();

            // Create schedule to hold the slots
            scheduleEntity.Fill(testSchedules.FirstOrDefaultSafe());
            scheduleEntity.Save();
            // 
            // Create specific times (time ranges)
            //
            slotRangeEntity.Fill(testSlotTimeRanges.FirstOrDefaultSafe());            
            slotRangeEntity.Save();
            // Save join record
            scheduleSlotEntity.ScheduleKey = scheduleEntity.Key;
            scheduleSlotEntity.ScheduleKey = slotRangeEntity.SlotKey;
            scheduleSlotEntity.Save();
            slotRangeEntity = new SlotTimeRange();
            slotRangeEntity.Fill(testSlotTimeRanges.LastOrDefaultSafe());
            slotRangeEntity.Save();
            // Join Record
            scheduleSlotEntity.ScheduleKey = scheduleEntity.Key;
            scheduleSlotEntity.ScheduleKey = slotRangeEntity.SlotKey;
            scheduleSlotEntity.Save();
            // 
            // Create recurring times
            //
            slotRecurEntity.Fill(testSlotTimeRecurring.FirstOrDefaultSafe());
            slotRecurEntity.Save();
            // Join Record
            scheduleSlotEntity.ScheduleKey = scheduleEntity.Key;
            scheduleSlotEntity.ScheduleKey = slotRecurEntity.SlotKey;
            scheduleSlotEntity.Save();
            slotRecurEntity = new SlotTimeRecurring();
            slotRecurEntity.Fill(testSlotTimeRecurring.LastOrDefaultSafe());
            slotRecurEntity.Save();
            // Join Record
            scheduleSlotEntity.ScheduleKey = scheduleEntity.Key;
            scheduleSlotEntity.ScheduleKey = slotRecurEntity.SlotKey;
            scheduleSlotEntity.Save();

            // Available by positive match tests


            // Unavailable by positive match tests


            // Holiday (unavailable) by positive match tests


        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<ScheduleInfo>();
            var reader = new EntityReader<ScheduleInfo>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
