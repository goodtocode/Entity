//-----------------------------------------------------------------------
// <copyright file="VentureScheduleTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Person;
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

namespace Genesys.Entity.Venture
{
    /// <summary>
    /// Venture Schedule tests
    /// </summary>
    [TestClass()]
    public class VentureScheduleTests
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

        List<VentureSchedule> testEntities = new List<VentureSchedule>()
        {
            new VentureSchedule() {VentureName = "Fall Semester", VentureDescription = "Fall semester classes", ScheduleName = "Student Schedule of Classes",  ScheduleDescription = "Student Schedule of Classes"},
            new VentureSchedule() {VentureName = "Spring Semester", VentureDescription = "Spring semester classes", ScheduleName = "Student Schedule of Classes", ScheduleDescription = "Student Schedule of Classes" },
            new VentureSchedule() {VentureName = "Newport Practice", VentureDescription = "Practice and group in Newport Beach", ScheduleName = "Normal Hours Schedule", ScheduleDescription = "Normal hours of operation"}
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
        /// Venture_VentureSchedule
        /// </summary>
        [TestMethod()]
        public void Venture_VentureSchedule_Create()
        {
            var testEntity = new VentureSchedule();
            var resultEntity = new VentureSchedule();
            var dbVenture = new VentureSchedule();
            var reader = new EntityReader<VentureSchedule>();
            var VentureTest = new VentureInfoTests();
            var personTest = new PersonInfoTests();

            // Create a base record
            VentureTest.Venture_VentureInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.VentureKey = VentureInfoTests.RecycleBin.LastOrDefault();
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

            VentureScheduleTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Venture_VentureSchedule
        /// </summary>
        [TestMethod()]
        public void Venture_VentureSchedule_Read()
        {
            var reader = new EntityReader<VentureSchedule>();
            var dbVenture = new VentureSchedule();
            var lastKey = Defaults.Guid;

            Venture_VentureSchedule_Create();
            lastKey = VentureScheduleTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Venture_VentureSchedule
        /// </summary>
        [TestMethod()]
        public void Venture_VentureSchedule_Update()
        {
            var reader = new EntityReader<VentureSchedule>();
            var writer = new StoredProcedureWriter<VentureSchedule>();
            var resultEntity = new VentureSchedule();
            var dbVenture = new VentureSchedule();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureSchedule_Create();
            lastKey = VentureScheduleTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbVenture.Id;
            originalKey = dbVenture.Key;
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);

            dbVenture.ScheduleName = uniqueValue;
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
        /// Venture_VentureSchedule
        /// </summary>
        [TestMethod()]
        public void Venture_VentureSchedule_Delete()
        {
            var reader = new EntityReader<VentureSchedule>();
            var dbVenture = new VentureSchedule();
            var result = new VentureSchedule();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureSchedule_Create();
            lastKey = VentureScheduleTests.RecycleBin.LastOrDefault();

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
        public void Venture_VentureSchedule_Serialize()
        {
            var searchChar = "i";
            var originalObject = new VentureSchedule() { ScheduleName = searchChar, ScheduleDescription = searchChar };
            var resultObject = new VentureSchedule();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<VentureSchedule>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.ScheduleName == searchChar);
            Assert.IsTrue(resultObject.ScheduleDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<VentureSchedule>();
            var reader = new EntityReader<VentureSchedule>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
