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

namespace GoodToCode.Entity.Location
{
    [TestClass()]
    public class LocationTimeRecurringTests
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

        List<LocationTimeRecurring> testEntities = new List<LocationTimeRecurring>()
        {
            new LocationTimeRecurring() {LocationName = "My House",  LocationDescription = "123 Main St", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new LocationTimeRecurring() {LocationName = "Your House", LocationDescription = "Corner of Main and Drain", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new LocationTimeRecurring() {LocationName = "Code World 2099", LocationDescription = "Town Center, SE Corner", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)}
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
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationTimeRecurring_Create()
        {
            var testEntity = new LocationTimeRecurring();
            var resultEntity = new LocationTimeRecurring();
            var reader = new EntityReader<LocationTimeRecurring>();
            var testClass = new LocationInfoTests();

            // Create a base record
            await testClass.Location_LocationInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.LocationKey = LocationInfoTests.RecycleBin.LastOrDefault();
            using (var writer = new EntityWriter<LocationTimeRecurring>(testEntity, new LocationTimeRecurringSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }

            Assert.IsTrue(!resultEntity.FailedRules.Any());
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);

            // Object in db should match in-memory objects
            testEntity = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id);
            Assert.IsTrue(testEntity.Key == resultEntity.Key);

            LocationTimeRecurringTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationTimeRecurring_Read()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var testEntity = new LocationTimeRecurring();
            var lastKey = Defaults.Guid;

            await Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationTimeRecurring_Update()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var resultEntity = new LocationTimeRecurring();
            var testEntity = new LocationTimeRecurring();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);

            testEntity.LocationName = uniqueValue;
            using (var writer = new EntityWriter<LocationTimeRecurring>(testEntity, new LocationTimeRecurringSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
        }

        /// <summary>
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationTimeRecurring_Delete()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var testEntity = new LocationTimeRecurring();
            var resultEntity = new LocationTimeRecurring();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);

            using (var writer = new EntityWriter<LocationTimeRecurring>(testEntity, new LocationTimeRecurringSPConfig()))
            {
                resultEntity = await writer.DeleteAsync();
            }
            Assert.IsTrue(resultEntity.IsNew);

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(testEntity.Id != originalId);
            Assert.IsTrue(testEntity.Key != originalKey);
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Location_LocationTimeRecurring_Serialize()
        {
            var searchChar = "i";
            var originalObject = new LocationTimeRecurring() { LocationName = searchChar, LocationDescription = searchChar };
            var resultObject = new LocationTimeRecurring();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<LocationTimeRecurring>();

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
        public static async Task Cleanup()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var toDelete = new LocationTimeRecurring();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new EntityWriter<LocationTimeRecurring>(toDelete, new LocationTimeRecurringSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
