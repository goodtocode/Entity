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

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture Resource tests
    /// </summary>
    [TestClass()]
    public class VentureResourceTests
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

        List<VentureResource> testEntities = new List<VentureResource>()
        {
            new VentureResource() {VentureName = "Fall Semester", VentureDescription = "Fall semester classes", ResourceName = "Math Instructor",  ResourceDescription = "Math Instructor Resource"},
            new VentureResource() {VentureName = "Spring Semester", VentureDescription = "Spring semester classes", ResourceName = "Science Instructor", ResourceDescription = "Science Instructor Resource" },
            new VentureResource() {VentureName = "Newport Practice", VentureDescription = "Practice and group in Newport Beach", ResourceName = "Hi Res Projector", ResourceDescription = "Hi Res Projector"}
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
        /// Venture_VentureResource
        /// </summary>
        [TestMethod()]
        public async Task Venture_VentureResource_Create()
        {
            var testEntity = new VentureResource();
            var resultEntity = new VentureResource();
            var reader = new EntityReader<VentureResource>();
            var VentureTest = new VentureInfoTests();
            var personTest = new PersonInfoTests();

            // Create a base record
            await VentureTest.Venture_VentureInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.VentureKey = VentureInfoTests.RecycleBin.LastOrDefault();
            using (var writer = new EntityWriter<VentureResource>(testEntity, new VentureResourceSPConfig()))
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

            VentureResourceTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Venture_VentureResource
        /// </summary>
        [TestMethod()]
        public async Task Venture_VentureResource_Read()
        {
            var reader = new EntityReader<VentureResource>();
            var testEntity = new VentureResource();
            var lastKey = Defaults.Guid;

            await Venture_VentureResource_Create();
            lastKey = VentureResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Venture_VentureResource
        /// </summary>
        [TestMethod()]
        public async Task Venture_VentureResource_Update()
        {
            var reader = new EntityReader<VentureResource>();
            var resultEntity = new VentureResource();
            var testEntity = new VentureResource();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Venture_VentureResource_Create();
            lastKey = VentureResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);

            testEntity.ResourceName = uniqueValue;
            using (var writer = new EntityWriter<VentureResource>(testEntity, new VentureResourceSPConfig()))
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
        /// Venture_VentureResource
        /// </summary>
        [TestMethod()]
        public async Task Venture_VentureResource_Delete()
        {
            var reader = new EntityReader<VentureResource>();
            var testEntity = new VentureResource();
            var resultEntity = new VentureResource();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Venture_VentureResource_Create();
            lastKey = VentureResourceTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);

            using (var writer = new EntityWriter<VentureResource>(testEntity, new VentureResourceSPConfig()))
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
        public async Task Venture_VentureResource_Serialize()
        {
            var searchChar = "i";
            var originalObject = new VentureResource() { ResourceName = searchChar, ResourceDescription = searchChar };
            var resultObject = new VentureResource();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<VentureResource>();

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
            var reader = new EntityReader<VentureResource>();
            var toDelete = new VentureResource();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new EntityWriter<VentureResource>(toDelete, new VentureResourceSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
