//-----------------------------------------------------------------------
// <copyright file="LocationTimeRecurringTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
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

namespace Genesys.Entity.Location
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
        public void Location_LocationTimeRecurring_Create()
        {
            var testEntity = new LocationTimeRecurring();
            var resultEntity = new LocationTimeRecurring();
            var dbEvent = new LocationTimeRecurring();
            var reader = new EntityReader<LocationTimeRecurring>();
            var testClass = new LocationInfoTests();

            // Create a base record
            testClass.Location_LocationInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.LocationKey = LocationInfoTests.RecycleBin.LastOrDefault();
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

            LocationTimeRecurringTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Location_LocationTimeRecurring_Read()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var dbEvent = new LocationTimeRecurring();
            var lastKey = Defaults.Guid;

            Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Location_LocationTimeRecurring_Update()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var writer = new StoredProcedureWriter<LocationTimeRecurring>();
            var resultEntity = new LocationTimeRecurring();
            var dbEvent = new LocationTimeRecurring();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEvent.Id;
            originalKey = dbEvent.Key;
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);

            dbEvent.LocationName = uniqueValue;
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
        /// Location_LocationTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Location_LocationTimeRecurring_Delete()
        {
            var reader = new EntityReader<LocationTimeRecurring>();
            var dbEvent = new LocationTimeRecurring();
            var result = new LocationTimeRecurring();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Location_LocationTimeRecurring_Create();
            lastKey = LocationTimeRecurringTests.RecycleBin.LastOrDefault();

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
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<LocationTimeRecurring>();
            var reader = new EntityReader<LocationTimeRecurring>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
