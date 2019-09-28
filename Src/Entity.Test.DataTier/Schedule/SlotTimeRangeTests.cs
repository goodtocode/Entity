using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Schedule
{
    [TestClass()]
    public class SlotTimeRangeTests
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

        List<SlotTimeRange> testEntities = new List<SlotTimeRange>()
        {
            new SlotTimeRange() {SlotName = "BBQ at my Housssseee!",  SlotDescription = "I want my baby back ribs!", BeginDate = DateTime.UtcNow.AddDays(30)},
            new SlotTimeRange() {SlotName = "Tutor After School", SlotDescription = "Meet you at the library for a tutor session.", BeginDate = DateTime.UtcNow.AddDays(40)},
            new SlotTimeRange() {SlotName = "Code World 2099", SlotDescription = "Nobody has to code anymore, but we cant stop anyways!", BeginDate = DateTime.UtcNow.AddDays(50)}
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
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRange_Create()
        {
            var testEntity = new SlotTimeRange();
            var resultEntity = new SlotTimeRange();
            var testItem = new SlotTimeRange();
            var reader = new EntityReader<SlotTimeRange>();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            resultEntity = testEntity.Save();
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Object in db should match in-memory objects
            testItem = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id);
            Assert.IsTrue(testItem.Key == resultEntity.Key);
            Assert.IsTrue(!testItem.FailedRules.Any());

            SlotTimeRangeTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRange_Read()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var testItem = new SlotTimeRange();
            var lastKey = Defaults.Guid;

            Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRange_Update()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var writer = new StoredProcedureWriter<SlotTimeRange>();
            var resultEntity = new SlotTimeRange();
            var testItem = new SlotTimeRange();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            resultEntity = testItem.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRange_Delete()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var testItem = new SlotTimeRange();
            var result = new SlotTimeRange();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());

            result = testItem.Delete();
            Assert.IsTrue(result.IsNew);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(testItem.Id != originalId);
            Assert.IsTrue(testItem.Key != originalKey);
            Assert.IsTrue(testItem.IsNew);
            Assert.IsTrue(testItem.Key == Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Schedule_SlotTimeRange_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotTimeRange() { SlotName = searchChar, SlotDescription = searchChar };
            var resultObject = new SlotTimeRange();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<SlotTimeRange>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.SlotName == searchChar);
            Assert.IsTrue(resultObject.SlotDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<SlotTimeRange>();
            var reader = new EntityReader<SlotTimeRange>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
