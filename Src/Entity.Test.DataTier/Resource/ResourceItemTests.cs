using GoodToCode.Entity.Resource;
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

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class ResourceItemTests
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

        List<ResourceItem> testEntities = new List<ResourceItem>()
        {
            new ResourceItem() {ResourceName = "Projectors", ResourceDescription = "All projectors", ItemName = "Projector", ItemDescription = "Low res projector" },
            new ResourceItem() {ResourceName = "Projectors", ResourceDescription = "All projectors", ItemName = "Projector", ItemDescription = "Medium res projector" },
            new ResourceItem() {ResourceName = "Projectors", ResourceDescription = "All projectors", ItemName = "Projector", ItemDescription = "High res projector" }
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
        /// Resource_ResourceItem
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceItem_Create()
        {
            var testEntity = new ResourceItem();
            var resultEntity = new ResourceItem();
            var testItem = new ResourceItem();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            resultEntity = testEntity.Save();
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            // Object in db should match in-memory objects
            testItem = ResourceItem.GetByKey(resultEntity.Key);
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id);
            Assert.IsTrue(testItem.Key == resultEntity.Key);
            Assert.IsTrue(!testItem.FailedRules.Any());

            ResourceItemTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Core_Resource_ResourceItem_Insert_Id
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Resource_ResourceItem_Create_Id()
        {
            var customerWriter = new StoredProcedureWriter<ResourceItem>();
            var testEntity = new ResourceItem();
            var resultEntity = new ResourceItem();
            var oldId = Defaults.Integer;
            var oldKey = Defaults.Guid;
            var newId = Defaults.Integer;
            var newKey = Defaults.Guid;

            // Create and insert record
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.Id = Defaults.Integer;
            testEntity.Key = Defaults.Guid;
            oldId = testEntity.Id;
            oldKey = testEntity.Key;
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == Defaults.Integer);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Do Insert and check passed entity and returned entity
            resultEntity = customerWriter.Create(testEntity);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Pull from DB and retest
            testEntity = new EntityReader<ResourceItem>().GetById(resultEntity.Id);
            Assert.IsTrue(testEntity.IsNew == false);
            Assert.IsTrue(testEntity.Id != oldId);
            Assert.IsTrue(testEntity.Key != oldKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Cleanup
            RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Core_Resource_ResourceItem_Insert_Key
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Resource_ResourceItem_Create_Key()
        {
            var customerWriter = new StoredProcedureWriter<ResourceItem>();
            var testEntity = new ResourceItem();
            var resultEntity = new ResourceItem();
            var oldId = Defaults.Integer;
            var oldKey = Defaults.Guid;
            var newId = Defaults.Integer;
            var newKey = Defaults.Guid;

            // Create and insert record
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.Id = Defaults.Integer;
            testEntity.Key = Guid.NewGuid();
            oldId = testEntity.Id;
            oldKey = testEntity.Key;
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Do Insert and check passed entity and returned entity
            resultEntity = customerWriter.Create(testEntity);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Pull from DB and retest
            testEntity = new EntityReader<ResourceItem>().GetById(resultEntity.Id);
            Assert.IsTrue(testEntity.IsNew == false);
            Assert.IsTrue(testEntity.Id != oldId);
            Assert.IsTrue(testEntity.Key == oldKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Cleanup
            RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Resource_ResourceItem
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceItem_Read()
        {
            var testItem = new ResourceItem();
            var lastKey = Defaults.Guid;

            Resource_ResourceItem_Create();
            lastKey = ResourceItemTests.RecycleBin.LastOrDefault();

            testItem = ResourceItem.GetByKey(lastKey);
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Resource_ResourceItem
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceItem_Update()
        {
            var resultEntity = new ResourceItem();
            var testItem = new ResourceItem();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Resource_ResourceItem_Create();
            lastKey = ResourceItemTests.RecycleBin.LastOrDefault();

            testItem = ResourceItem.GetByKey(lastKey);
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem.ItemName = uniqueValue;
            testItem.ResourceName = uniqueValue;
            resultEntity = testItem.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem = ResourceItem.GetByKey(originalKey);
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Resource_ResourceItem
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceItem_Delete()
        {
            var testItem = new ResourceItem();
            var result = new ResourceItem();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Resource_ResourceItem_Create();
            lastKey = ResourceItemTests.RecycleBin.LastOrDefault();

            testItem = ResourceItem.GetByKey(lastKey);
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);

            result = testItem.Delete();
            Assert.IsTrue(result.IsNew);
            Assert.IsTrue(!result.FailedRules.Any());

            testItem = ResourceItem.GetByKey(originalKey);
            Assert.IsTrue(testItem.Id != originalId);
            Assert.IsTrue(testItem.Key != originalKey);
            Assert.IsTrue(testItem.IsNew);
            Assert.IsTrue(testItem.Key == Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }


        [TestMethod()]
        public void Resource_ResourceItem_Serialize()
        {
            var searchChar = "i";
            var originalObject = new ResourceItem() { ResourceName = searchChar, ItemName = searchChar };
            var resultObject = new ResourceItem();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<ResourceItem>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.ResourceName == searchChar);
            Assert.IsTrue(resultObject.ItemName == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<ResourceItem>();
            var reader = new EntityReader<ResourceItem>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}