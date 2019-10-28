using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Extensions.Serialization;
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
    public class SlotTimeRecurringTests
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

        List<SlotTimeRecurring> testEntities = new List<SlotTimeRecurring>()
        {
            new SlotTimeRecurring() {SlotName = "BBQ at my Housssseee!",  SlotDescription = "I want my baby back ribs!", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new SlotTimeRecurring() {SlotName = "Tutor After School", SlotDescription = "Meet you at the library for a tutor session.", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new SlotTimeRecurring() {SlotName = "Code World 2099", SlotDescription = "Nobody has to code anymore, but we cant stop anyways!", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
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
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRecurring_Create()
        {
            var testEntity = new SlotTimeRecurring();
            var resultEntity = new SlotTimeRecurring();
            var reader = new EntityReader<SlotTimeRecurring>();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            using (var writer = new StoredProcedureWriter<SlotTimeRecurring>(testEntity, new SlotTimeRecurringSPConfig()))
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

            SlotTimeRecurringTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRecurring_Read()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var testEntity = new SlotTimeRecurring();
            var lastKey = Defaults.Guid;

            await Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRecurring_Update()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var resultEntity = new SlotTimeRecurring();
            var testEntity = new SlotTimeRecurring();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity.SlotName = uniqueValue;
            using (var writer = new StoredProcedureWriter<SlotTimeRecurring>(testEntity, new SlotTimeRecurringSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRecurring_Delete()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var testEntity = new SlotTimeRecurring();
            var resultEntity = new SlotTimeRecurring();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            using (var writer = new StoredProcedureWriter<SlotTimeRecurring>(testEntity, new SlotTimeRecurringSPConfig()))
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

        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotTimeRecurring() { SlotName = searchChar, SlotDescription = searchChar };
            var serializer = new JsonSerializer<SlotTimeRecurring>();

            var resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            var resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.SlotName == searchChar);
            Assert.IsTrue(resultObject.SlotDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var toDelete = new SlotTimeRecurring();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new StoredProcedureWriter<SlotTimeRecurring>(toDelete, new SlotTimeRecurringSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
