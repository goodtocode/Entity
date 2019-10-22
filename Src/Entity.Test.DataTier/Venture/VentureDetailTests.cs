using GoodToCode.Entity.Detail;
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

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture Detail tests
    /// </summary>
    [TestClass()]
    public class VentureDetailTests
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

        List<VentureDetail> testEntities = new List<VentureDetail>()
        {
            new VentureDetail() {Description = "Fall semester classes"},
            new VentureDetail() {Description = "Spring semester classes" },
            new VentureDetail() { Description  = "Practice and group in Newport Beach"}
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
        /// Venture_VentureDetail
        /// </summary>
        [TestMethod()]
        public void Venture_VentureDetail_Create()
        {
            var testEntity = new VentureDetail();
            var resultEntity = new VentureDetail();
            var dbVenture = new VentureDetail();
            var reader = new EntityReader<VentureDetail>();
            var VentureTest = new VentureInfoTests();

            // Create a base record
            VentureTest.Venture_VentureInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.VentureKey = VentureInfoTests.RecycleBin.LastOrDefault();
            testEntity.DetailTypeKey = DetailTypes.Directions;
            resultEntity = testEntity.Save();
            Assert.IsTrue(!resultEntity.FailedRules.Any());
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);

            // Object in db should match in-memory objects
            dbVenture = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.Id == resultEntity.Id);
            Assert.IsTrue(dbVenture.Key == resultEntity.Key);

            VentureDetailTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Venture_VentureDetail
        /// </summary>
        [TestMethod()]
        public void Venture_VentureDetail_Read()
        {
            var reader = new EntityReader<VentureDetail>();
            var dbVenture = new VentureDetail();
            var lastKey = Defaults.Guid;

            Venture_VentureDetail_Create();
            lastKey = VentureDetailTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Venture_VentureDetail
        /// </summary>
        [TestMethod()]
        public void Venture_VentureDetail_Update()
        {
            var reader = new EntityReader<VentureDetail>();
            var writer = new StoredProcedureWriter<VentureDetail>();
            var resultEntity = new VentureDetail();
            var dbVenture = new VentureDetail();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureDetail_Create();
            lastKey = VentureDetailTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbVenture.Id;
            originalKey = dbVenture.Key;
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);

            dbVenture.Description = uniqueValue;
            resultEntity = dbVenture.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbVenture.Key == resultEntity.Key && resultEntity.Key == originalKey);

            dbVenture = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbVenture.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
        }

        /// <summary>
        /// Venture_VentureDetail
        /// </summary>
        [TestMethod()]
        public void Venture_VentureDetail_Delete()
        {
            var reader = new EntityReader<VentureDetail>();
            var dbVenture = new VentureDetail();
            var result = new VentureDetail();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureDetail_Create();
            lastKey = VentureDetailTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbVenture.Id;
            originalKey = dbVenture.Key;
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.CreatedDate.Date == DateTime.UtcNow.Date);

            result = dbVenture.Delete();
            Assert.IsTrue(result.IsNew);

            dbVenture = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(dbVenture.Id != originalId);
            Assert.IsTrue(dbVenture.Key != originalKey);
            Assert.IsTrue(dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Key == Defaults.Guid);

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Venture_VentureDetail_Serialize()
        {
            var searchChar = "i";
            var originalObject = new VentureDetail() { Description = searchChar };
            var resultObject = new VentureDetail();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<VentureDetail>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.Description == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<VentureDetail>();
            var reader = new EntityReader<VentureDetail>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
