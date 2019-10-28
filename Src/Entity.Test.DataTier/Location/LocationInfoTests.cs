
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

namespace GoodToCode.Entity.Location
{
    [TestClass()]
    public class LocationInfoTests
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

        List<LocationInfo> testEntities = new List<LocationInfo>()
        {
            new LocationInfo() {Name = "BBQ at my Housssseee!",  Description = "I want my baby back ribs!"},
            new LocationInfo() {Name = "Tutor After School", Description = "Meet you at the library for a tutor session."},
            new LocationInfo() {Name = "Code World 2099", Description = "Nobody has to code anymore, but we cant stop anyways!"}
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
        /// Location_LocationInfo
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationInfo_Create()
        {
            var testEntity = new LocationInfo();
            var resultEntity = new LocationInfo();
            var reader = new EntityReader<LocationInfo>();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            using (var writer = new StoredProcedureWriter<LocationInfo>(testEntity, new LocationInfoSPConfig()))
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

            LocationInfoTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Location_LocationInfo
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationInfo_Read()
        {
            var reader = new EntityReader<LocationInfo>();
            var testEntity = new LocationInfo();
            var lastKey = Defaults.Guid;

            await Location_LocationInfo_Create();
            lastKey = LocationInfoTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Location_LocationInfo
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationInfo_Update()
        {
            var reader = new EntityReader<LocationInfo>();
            var resultEntity = new LocationInfo();
            var testEntity = new LocationInfo();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Location_LocationInfo_Create();
            lastKey = LocationInfoTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity.Name = uniqueValue;
            using (var writer = new StoredProcedureWriter<LocationInfo>(testEntity, new LocationInfoSPConfig()))
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
        /// Location_LocationInfo
        /// </summary>
        [TestMethod()]
        public async Task Location_LocationInfo_Delete()
        {
            var reader = new EntityReader<LocationInfo>();
            var testEntity = new LocationInfo();
            var resultEntity = new LocationInfo();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Location_LocationInfo_Create();
            lastKey = LocationInfoTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            using (var writer = new StoredProcedureWriter<LocationInfo>(testEntity, new LocationInfoSPConfig()))
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
        public void Location_LocationInfo_Serialize()
        {
            var searchChar = "i";
            var originalObject = new LocationInfo() { Name = searchChar, Description = searchChar };
            var resultObject = new LocationInfo();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<LocationInfo>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.Name == searchChar);
            Assert.IsTrue(resultObject.Description == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<LocationInfo>();
            var toDelete = new LocationInfo();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new StoredProcedureWriter<LocationInfo>(toDelete, new LocationInfoSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
