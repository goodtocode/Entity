//-----------------------------------------------------------------------
// <copyright file="ResourceInfoTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Resource;
using Genesys.Extensions;
using Genesys.Extras.Configuration;
using Genesys.Extras.Mathematics;
using Genesys.Extras.Serialization;
using Genesys.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace Genesys.Entity.Resource
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class ResourceInfoTests
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

        List<ResourceInfo> testEntities = new List<ResourceInfo>()
        {
            new ResourceInfo() {Name = "Projector", Description = "Low res projector" },
            new ResourceInfo() {Name = "Projector", Description = "Medium res projector" },
            new ResourceInfo() {Name = "Projector", Description = "High res projector" }
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
        /// Resource_ResourceInfo
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceInfo_Create()
        {
            var testEntity = new ResourceInfo();
            var resultEntity = new ResourceInfo();
            var testResource = new ResourceInfo();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            resultEntity = testEntity.Save();
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testResource.FailedRules.Any());

            // Object in db should match in-memory objects
            testResource = ResourceInfo.GetByKey(resultEntity.Key);
            Assert.IsTrue(!testResource.IsNew);
            Assert.IsTrue(testResource.Id != Defaults.Integer);
            Assert.IsTrue(testResource.Key != Defaults.Guid);
            Assert.IsTrue(testResource.Id == resultEntity.Id);
            Assert.IsTrue(testResource.Key == resultEntity.Key);
            Assert.IsTrue(!testResource.FailedRules.Any());

            ResourceInfoTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Core_Resource_ResourceInfo_Insert_Id
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Resource_ResourceInfo_Create_Id()
        {
            var customerWriter = new StoredProcedureWriter<ResourceInfo>();
            var testEntity = new ResourceInfo();
            var resultEntity = new ResourceInfo();
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
            testEntity = new EntityReader<ResourceInfo>().GetById(resultEntity.Id);
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
        /// Core_Resource_ResourceInfo_Insert_Key
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Resource_ResourceInfo_Create_Key()
        {
            var customerWriter = new StoredProcedureWriter<ResourceInfo>();
            var testEntity = new ResourceInfo();
            var resultEntity = new ResourceInfo();
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
            testEntity = new EntityReader<ResourceInfo>().GetById(resultEntity.Id);
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
        /// Resource_ResourceInfo
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceInfo_Read()
        {
            var testResource = new ResourceInfo();
            var lastKey = Defaults.Guid;

            Resource_ResourceInfo_Create();
            lastKey = ResourceInfoTests.RecycleBin.LastOrDefault();

            testResource = ResourceInfo.GetByKey(lastKey);
            Assert.IsTrue(!testResource.IsNew);
            Assert.IsTrue(testResource.Id != Defaults.Integer);
            Assert.IsTrue(testResource.Key != Defaults.Guid);
            Assert.IsTrue(testResource.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testResource.FailedRules.Any());
        }

        /// <summary>
        /// Resource_ResourceInfo
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceInfo_Update()
        {
            var resultEntity = new ResourceInfo();
            var testResource = new ResourceInfo();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Resource_ResourceInfo_Create();
            lastKey = ResourceInfoTests.RecycleBin.LastOrDefault();

            testResource = ResourceInfo.GetByKey(lastKey);
            originalId = testResource.Id;
            originalKey = testResource.Key;
            Assert.IsTrue(!testResource.IsNew);
            Assert.IsTrue(testResource.Id != Defaults.Integer);
            Assert.IsTrue(testResource.Key != Defaults.Guid);
            Assert.IsTrue(!testResource.FailedRules.Any());

            testResource.Name = uniqueValue;
            resultEntity = testResource.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testResource.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testResource.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testResource.FailedRules.Any());

            testResource = ResourceInfo.GetByKey(originalKey);
            Assert.IsTrue(!testResource.IsNew);
            Assert.IsTrue(testResource.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testResource.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testResource.Id != Defaults.Integer);
            Assert.IsTrue(testResource.Key != Defaults.Guid);
            Assert.IsTrue(!testResource.FailedRules.Any());
        }

        /// <summary>
        /// Resource_ResourceInfo
        /// </summary>
        [TestMethod()]
        public void Resource_ResourceInfo_Delete()
        {
            var testResource = new ResourceInfo();
            var result = new ResourceInfo();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Resource_ResourceInfo_Create();
            lastKey = ResourceInfoTests.RecycleBin.LastOrDefault();

            testResource = ResourceInfo.GetByKey(lastKey);
            originalId = testResource.Id;
            originalKey = testResource.Key;
            Assert.IsTrue(testResource.Id != Defaults.Integer);
            Assert.IsTrue(testResource.Key != Defaults.Guid);
            Assert.IsTrue(testResource.CreatedDate.Date == DateTime.UtcNow.Date);

            result = testResource.Delete();
            Assert.IsTrue(result.IsNew);
            Assert.IsTrue(!result.FailedRules.Any());

            testResource = ResourceInfo.GetByKey(originalKey);
            Assert.IsTrue(testResource.Id != originalId);
            Assert.IsTrue(testResource.Key != originalKey);
            Assert.IsTrue(testResource.IsNew);
            Assert.IsTrue(testResource.Key == Defaults.Guid);
            Assert.IsTrue(!testResource.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }


        [TestMethod()]
        public void Resource_ResourceInfo_Serialize()
        {
            var searchChar = "i";
            var originalObject = new ResourceInfo() { Name = searchChar };
            var resultObject = new ResourceInfo();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<ResourceInfo>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.Name == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<ResourceInfo>();
            var reader = new EntityReader<ResourceInfo>();
            foreach (Guid Resource in RecycleBin)
            {
                writer.Delete(reader.GetByKey(Resource));
            }
        }
    }
}