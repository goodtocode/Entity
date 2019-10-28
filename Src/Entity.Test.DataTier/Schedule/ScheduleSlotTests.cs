using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Schedule
{
    [TestClass()]
    public class ScheduleSlotTests
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
        /// Schedule_ScheduleSlot
        /// </summary>
        [TestMethod()]
        public async Task Schedule_ScheduleSlot_Create()
        {
            var testEntity = new ScheduleSlot();
            var resultEntity = new ScheduleSlot();
            var reader = new EntityReader<ScheduleSlot>();
            var scheduleTest = new ScheduleInfoTests();
            var slotTest = new SlotInfoTests();

            // Create base records
            await scheduleTest.Schedule_ScheduleInfo_Create();
            testEntity.ScheduleKey = ScheduleInfoTests.RecycleBin.LastOrDefault();
            await slotTest.Schedule_SlotInfo_Create();
            testEntity.SlotKey = SlotInfoTests.RecycleBin.LastOrDefault();

            // Create should update original object, and pass back a fresh-from-db object
            using (var writer = new StoredProcedureWriter<ScheduleSlot>(testEntity, new ScheduleSlotSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Object in db should match in-memory objects
            testEntity = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id);
            Assert.IsTrue(testEntity.Key == resultEntity.Key);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            ScheduleSlotTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_ScheduleSlot
        /// </summary>
        [TestMethod()]
        public async Task Schedule_ScheduleSlot_Read()
        {
            var reader = new EntityReader<ScheduleSlot>();
            var testEntity = new ScheduleSlot();
            var lastKey = Defaults.Guid;

            await Schedule_ScheduleSlot_Create();
            lastKey = ScheduleSlotTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }


        /// <summary>
        /// Schedule_ScheduleSlot
        /// </summary>
        [TestMethod()]
        public async Task Schedule_ScheduleSlot_Delete()
        {
            var reader = new EntityReader<ScheduleSlot>();
            var testEntity = new ScheduleSlot();
            var resultEntity = new ScheduleSlot();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_ScheduleSlot_Create();
            lastKey = ScheduleSlotTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            using (var writer = new StoredProcedureWriter<ScheduleSlot>(testEntity, new ScheduleSlotSPConfig()))
            {
                resultEntity = await writer.DeleteAsync();
            }
            Assert.IsTrue(resultEntity.IsNew);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(testEntity.Id != originalId);
            Assert.IsTrue(testEntity.Key != originalKey);
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<ScheduleSlot>();
            var toDelete = new ScheduleSlot();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new StoredProcedureWriter<ScheduleSlot>(toDelete, new ScheduleSlotSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
