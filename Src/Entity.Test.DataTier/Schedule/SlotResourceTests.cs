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
    /// <summary>
    /// Slot Resource tests
    /// </summary>
    [TestClass()]
    public class SlotResourceTests
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

        List<SlotResource> testEntities = new List<SlotResource>()
        {
            new SlotResource() {SlotName = "Morning shift", SlotDescription = "Morning shift tuesdays", ResourceName = "My House",  ResourceDescription = "123 Main St"},
            new SlotResource() {SlotName = "Afternoon shift", SlotDescription = "Afternoon shift all days", ResourceName = "Your House", ResourceDescription = "Corner of Main and Drain"},
            new SlotResource() {SlotName = "Weekends", SlotDescription = "Weekends only", ResourceName = "Code World 2099", ResourceDescription = "Town Center, SE Corner"}
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
        /// Schedule_SlotResource
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotResource_Create()
        {
            var testEntity = new SlotResource();
            var resultEntity = new SlotResource();
            var reader = new EntityReader<SlotResource>();
            var SlotTest = new SlotInfoTests();

            // Create a base record
            await SlotTest.Schedule_SlotInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.SlotKey = SlotInfoTests.RecycleBin.LastOrDefault();
            using (var writer = new EntityWriter<SlotResource>(testEntity, new SlotResourceSPConfig()))
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

            SlotResourceTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotResource
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotResource_Read()
        {
            var reader = new EntityReader<SlotResource>();
            var testEntity = new SlotResource();
            var lastKey = Defaults.Guid;

            await Schedule_SlotResource_Create();
            lastKey = SlotResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Schedule_SlotResource
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotResource_Update()
        {
            var reader = new EntityReader<SlotResource>();
            var resultEntity = new SlotResource();
            var testEntity = new SlotResource();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotResource_Create();
            lastKey = SlotResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);

            testEntity.ResourceName = uniqueValue;
            using (var writer = new EntityWriter<SlotResource>(testEntity, new SlotResourceSPConfig()))
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
        /// Schedule_SlotResource
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotResource_Delete()
        {
            var reader = new EntityReader<SlotResource>();
            var testEntity = new SlotResource();
            var resultEntity = new SlotResource();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotResource_Create();
            lastKey = SlotResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);

            using (var writer = new EntityWriter<SlotResource>(testEntity, new SlotResourceSPConfig()))
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
        public void Schedule_SlotResource_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotResource() { ResourceName = searchChar, ResourceDescription = searchChar };
            var resultObject = new SlotResource();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<SlotResource>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.ResourceName == searchChar);
            Assert.IsTrue(resultObject.ResourceDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<SlotResource>();
            var toDelete = new SlotResource();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new EntityWriter<SlotResource>(toDelete, new SlotResourceSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
