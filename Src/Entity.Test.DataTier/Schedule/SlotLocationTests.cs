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
    /// <summary>
    /// Slot Location tests
    /// </summary>
    [TestClass()]
    public class SlotLocationTests
    {
        private static readonly object LockObject = new object();
        private static volatile List<Guid> _recycleBin = null;
        /// <summary>
        /// Singleton for recycle bin
        /// </summary>
        private static List<Guid> RecycleBin
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

        List<SlotLocation> testEntities = new List<SlotLocation>()
        {
            new SlotLocation() {SlotName = "Morning shift", SlotDescription = "Morning shift tuesdays", LocationName = "My House",  LocationDescription = "123 Main St"},
            new SlotLocation() {SlotName = "Afternoon shift", SlotDescription = "Afternoon shift all days", LocationName = "Your House", LocationDescription = "Corner of Main and Drain"},
            new SlotLocation() {SlotName = "Weekends", SlotDescription = "Weekends only", LocationName = "Code World 2099", LocationDescription = "Town Center, SE Corner"}
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
        /// Schedule_SlotLocation
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotLocation_Create()
        {
            var testEntity = new SlotLocation();
            var resultEntity = new SlotLocation();
            var dbSlot = new SlotLocation();
            var reader = new EntityReader<SlotLocation>();
            var slotTest = new SlotInfoTests();

            // Create a base record
            slotTest.Schedule_SlotInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.SlotKey = SlotInfoTests.RecycleBin.LastOrDefault();
            resultEntity = testEntity.Save();
            Assert.IsTrue(!resultEntity.FailedRules.Any());
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);

            // Object in db should match in-memory objects
            dbSlot = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!dbSlot.IsNew);
            Assert.IsTrue(dbSlot.Id != Defaults.Integer);
            Assert.IsTrue(dbSlot.Key != Defaults.Guid);
            Assert.IsTrue(dbSlot.Id == resultEntity.Id);
            Assert.IsTrue(dbSlot.Key == resultEntity.Key);

            SlotLocationTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotLocation
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotLocation_Read()
        {
            var reader = new EntityReader<SlotLocation>();
            var dbSlot = new SlotLocation();
            var lastKey = Defaults.Guid;

            Schedule_SlotLocation_Create();
            lastKey = SlotLocationTests.RecycleBin.LastOrDefault();

            dbSlot = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbSlot.IsNew);
            Assert.IsTrue(dbSlot.Id != Defaults.Integer);
            Assert.IsTrue(dbSlot.Key != Defaults.Guid);
            Assert.IsTrue(dbSlot.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Schedule_SlotLocation
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotLocation_Update()
        {
            var reader = new EntityReader<SlotLocation>();
            var writer = new StoredProcedureWriter<SlotLocation>();
            var resultEntity = new SlotLocation();
            var dbSlot = new SlotLocation();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotLocation_Create();
            lastKey = SlotLocationTests.RecycleBin.LastOrDefault();

            dbSlot = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbSlot.Id;
            originalKey = dbSlot.Key;
            Assert.IsTrue(!dbSlot.IsNew);
            Assert.IsTrue(dbSlot.Id != Defaults.Integer);
            Assert.IsTrue(dbSlot.Key != Defaults.Guid);

            dbSlot.LocationName = uniqueValue;
            resultEntity = dbSlot.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbSlot.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbSlot.Key == resultEntity.Key && resultEntity.Key == originalKey);

            dbSlot = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!dbSlot.IsNew);
            Assert.IsTrue(dbSlot.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbSlot.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(dbSlot.Id != Defaults.Integer);
            Assert.IsTrue(dbSlot.Key != Defaults.Guid);
        }

        /// <summary>
        /// Schedule_SlotLocation
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotLocation_Delete()
        {
            var reader = new EntityReader<SlotLocation>();
            var dbSlot = new SlotLocation();
            var result = new SlotLocation();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotLocation_Create();
            lastKey = SlotLocationTests.RecycleBin.LastOrDefault();

            dbSlot = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbSlot.Id;
            originalKey = dbSlot.Key;
            Assert.IsTrue(dbSlot.Id != Defaults.Integer);
            Assert.IsTrue(dbSlot.Key != Defaults.Guid);
            Assert.IsTrue(dbSlot.CreatedDate.Date == DateTime.UtcNow.Date);

            result = dbSlot.Delete();
            Assert.IsTrue(result.IsNew);

            dbSlot = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(dbSlot.Id != originalId);
            Assert.IsTrue(dbSlot.Key != originalKey);
            Assert.IsTrue(dbSlot.IsNew);
            Assert.IsTrue(dbSlot.Key == Defaults.Guid);

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Schedule_SlotLocation_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotLocation() { LocationName = searchChar, LocationDescription = searchChar };
            var resultObject = new SlotLocation();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<SlotLocation>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.LocationName == searchChar);
            Assert.IsTrue(resultObject.LocationDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<SlotLocation>();
            var reader = new EntityReader<SlotLocation>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
