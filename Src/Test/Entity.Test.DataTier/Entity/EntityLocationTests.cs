//-----------------------------------------------------------------------
// <copyright file="EntityLocationTests.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Location;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extras.Configuration;
using GoodToCode.Extras.Mathematics;
using GoodToCode.Extras.Serialization;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity Location tests
    /// </summary>
    [TestClass()]
    public class EntityLocationTests
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

        List<EntityLocation> testEntities = new List<EntityLocation>()
        {
            new EntityLocation() {LocationName = "Building Pod A",  LocationDescription = "Student Location of Classes"},
            new EntityLocation() {LocationName = "Building Pod B", LocationDescription = "Student Location of Classes" },
            new EntityLocation() {LocationName = "123 Main St, NB, Ca.", LocationDescription = "Normal hours of operation"}
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
        /// Entity_EntityLocation
        /// </summary>
        [TestMethod()]
        public void Entity_EntityLocation_Create()
        {
            var testEntity = new EntityLocation();
            var resultEntity = new EntityLocation();
            var dbEntity = new EntityLocation();
            var reader = new EntityReader<EntityLocation>();
            var testClass = new PersonInfoTests();
            var testClassLocation = new LocationInfoTests();

            // Create Entity
            testClass.Person_PersonInfo_Create();
            testClassLocation.Location_LocationInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.EntityKey = PersonInfoTests.RecycleBin.LastOrDefault();
            testEntity.LocationKey = LocationInfoTests.RecycleBin.LastOrDefault();
            resultEntity = testEntity.Save();
            Assert.IsTrue(!resultEntity.FailedRules.Any());
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);

            // Object in db should match in-memory objects
            dbEntity = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEntity.IsNew);
            Assert.IsTrue(dbEntity.Id != Defaults.Integer);
            Assert.IsTrue(dbEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbEntity.Id == resultEntity.Id);
            Assert.IsTrue(dbEntity.Key == resultEntity.Key);

            EntityLocationTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Entity_EntityLocation
        /// </summary>
        [TestMethod()]
        public void Entity_EntityLocation_Read()
        {
            var reader = new EntityReader<EntityLocation>();
            var dbEntity = new EntityLocation();
            var lastKey = Defaults.Guid;

            Entity_EntityLocation_Create();
            lastKey = EntityLocationTests.RecycleBin.LastOrDefault();

            dbEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEntity.IsNew);
            Assert.IsTrue(dbEntity.Id != Defaults.Integer);
            Assert.IsTrue(dbEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbEntity.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Entity_EntityLocation
        /// </summary>
        [TestMethod()]
        public void Entity_EntityLocation_Update()
        {
            var reader = new EntityReader<EntityLocation>();
            var writer = new StoredProcedureWriter<EntityLocation>();
            var resultEntity = new EntityLocation();
            var dbEntity = new EntityLocation();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Entity_EntityLocation_Create();
            lastKey = EntityLocationTests.RecycleBin.LastOrDefault();

            dbEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEntity.Id;
            originalKey = dbEntity.Key;
            Assert.IsTrue(!dbEntity.IsNew);
            Assert.IsTrue(dbEntity.Id != Defaults.Integer);
            Assert.IsTrue(dbEntity.Key != Defaults.Guid);

            dbEntity.LocationName = uniqueValue;
            resultEntity = dbEntity.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);

            dbEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEntity.IsNew);
            Assert.IsTrue(dbEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(dbEntity.Id != Defaults.Integer);
            Assert.IsTrue(dbEntity.Key != Defaults.Guid);
        }

        /// <summary>
        /// Entity_EntityLocation
        /// </summary>
        [TestMethod()]
        public void Entity_EntityLocation_Delete()
        {
            var reader = new EntityReader<EntityLocation>();
            var dbEntity = new EntityLocation();
            var result = new EntityLocation();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Entity_EntityLocation_Create();
            lastKey = EntityLocationTests.RecycleBin.LastOrDefault();

            dbEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEntity.Id;
            originalKey = dbEntity.Key;
            Assert.IsTrue(dbEntity.Id != Defaults.Integer);
            Assert.IsTrue(dbEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbEntity.CreatedDate.Date == DateTime.UtcNow.Date);

            result = dbEntity.Delete();
            Assert.IsTrue(result.IsNew);

            dbEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(dbEntity.Id != originalId);
            Assert.IsTrue(dbEntity.Key != originalKey);
            Assert.IsTrue(dbEntity.IsNew);
            Assert.IsTrue(dbEntity.Key == Defaults.Guid);

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Entity_EntityLocation_Serialize()
        {
            var searchChar = "i";
            var originalObject = new EntityLocation() { LocationName = searchChar, LocationDescription = searchChar };
            var resultObject = new EntityLocation();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<EntityLocation>();

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
            var writer = new StoredProcedureWriter<EntityLocation>();
            var reader = new EntityReader<EntityLocation>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
