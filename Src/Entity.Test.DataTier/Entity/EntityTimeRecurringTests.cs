//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity
{
    [TestClass()]
    public class EntityTimeRecurringTests
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

        List<EntityTimeRecurring> testEntities = new List<EntityTimeRecurring>()
        {
            new EntityTimeRecurring() {BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new EntityTimeRecurring() {BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new EntityTimeRecurring() {BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)}
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
        /// Entity_EntityTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Entity_EntityTimeRecurring_Create()
        {
            var testEntity = new EntityTimeRecurring();
            var resultEntity = new EntityTimeRecurring();
            var dbEvent = new EntityTimeRecurring();
            var reader = new EntityReader<EntityTimeRecurring>();
            var testClass = new PersonInfoTests();

            // Create a base record
            testClass.Person_PersonInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.EntityKey = PersonInfoTests.RecycleBin.LastOrDefault();
            resultEntity = testEntity.Save();
            Assert.IsTrue(!resultEntity.FailedRules.Any());
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);

            // Object in db should match in-memory objects
            dbEvent = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.Id == resultEntity.Id);
            Assert.IsTrue(dbEvent.Key == resultEntity.Key);

            EntityTimeRecurringTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Entity_EntityTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Entity_EntityTimeRecurring_Read()
        {
            var reader = new EntityReader<EntityTimeRecurring>();
            var dbEvent = new EntityTimeRecurring();
            var lastKey = Defaults.Guid;

            Entity_EntityTimeRecurring_Create();
            lastKey = EntityTimeRecurringTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Entity_EntityTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Entity_EntityTimeRecurring_Update()
        {
            var reader = new EntityReader<EntityTimeRecurring>();
            var writer = new StoredProcedureWriter<EntityTimeRecurring>();
            var resultEntity = new EntityTimeRecurring();
            var dbEvent = new EntityTimeRecurring();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Entity_EntityTimeRecurring_Create();
            lastKey = EntityTimeRecurringTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEvent.Id;
            originalKey = dbEvent.Key;
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);

            resultEntity = dbEvent.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbEvent.Key == resultEntity.Key && resultEntity.Key == originalKey);

            dbEvent = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(dbEvent.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
        }

        /// <summary>
        /// Entity_EntityTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Entity_EntityTimeRecurring_Delete()
        {
            var reader = new EntityReader<EntityTimeRecurring>();
            var dbEvent = new EntityTimeRecurring();
            var result = new EntityTimeRecurring();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Entity_EntityTimeRecurring_Create();
            lastKey = EntityTimeRecurringTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEvent.Id;
            originalKey = dbEvent.Key;
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.CreatedDate.Date == DateTime.UtcNow.Date);

            result = dbEvent.Delete();
            Assert.IsTrue(result.IsNew);

            dbEvent = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(dbEvent.Id != originalId);
            Assert.IsTrue(dbEvent.Key != originalKey);
            Assert.IsTrue(dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Key == Defaults.Guid);

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<EntityTimeRecurring>();
            var reader = new EntityReader<EntityTimeRecurring>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
