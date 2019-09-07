//-----------------------------------------------------------------------
// <copyright file="VentureAppointmentTests.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture Appointment tests
    /// </summary>
    [TestClass()]
    public class VentureAppointmentTests
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

        List<VentureAppointment> testEntities = new List<VentureAppointment>()
        {
            new VentureAppointment() {VentureName = "Fall Semester", VentureDescription = "Fall semester classes", AppointmentName = "Building Pod A",  AppointmentDescription = "Student Appointment of Classes", BeginDate = DateTime.UtcNow.AddDays(30)},
            new VentureAppointment() {VentureName = "Spring Semester", VentureDescription = "Spring semester classes", AppointmentName = "Building Pod B", AppointmentDescription = "Student Appointment of Classes", BeginDate = DateTime.UtcNow.AddDays(60)},
            new VentureAppointment() {VentureName = "Newport Practice", VentureDescription = "Practice and group in Newport Beach", AppointmentName = "123 Main St, NB, Ca.", AppointmentDescription = "Normal hours of operation", BeginDate = DateTime.UtcNow.AddDays(90)}
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
        /// Venture_VentureAppointment
        /// </summary>
        [TestMethod()]
        public void Venture_VentureAppointment_Create()
        {
            var testEntity = new VentureAppointment();
            var resultEntity = new VentureAppointment();
            var dbVenture = new VentureAppointment();
            var reader = new EntityReader<VentureAppointment>();
            var testClass = new VentureInfoTests();

            // Create Venture
            testClass.Venture_VentureInfo_Create();
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

            VentureAppointmentTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Venture_VentureAppointment
        /// </summary>
        [TestMethod()]
        public void Venture_VentureAppointment_Read()
        {
            var reader = new EntityReader<VentureAppointment>();
            var dbVenture = new VentureAppointment();
            var lastKey = Defaults.Guid;

            Venture_VentureAppointment_Create();
            lastKey = VentureAppointmentTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);
            Assert.IsTrue(dbVenture.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Venture_VentureAppointment
        /// </summary>
        [TestMethod()]
        public void Venture_VentureAppointment_Update()
        {
            var reader = new EntityReader<VentureAppointment>();
            var writer = new StoredProcedureWriter<VentureAppointment>();
            var resultEntity = new VentureAppointment();
            var dbVenture = new VentureAppointment();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureAppointment_Create();
            lastKey = VentureAppointmentTests.RecycleBin.LastOrDefault();

            dbVenture = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbVenture.Id;
            originalKey = dbVenture.Key;
            Assert.IsTrue(!dbVenture.IsNew);
            Assert.IsTrue(dbVenture.Id != Defaults.Integer);
            Assert.IsTrue(dbVenture.Key != Defaults.Guid);

            dbVenture.AppointmentName = uniqueValue;
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
        /// Venture_VentureAppointment
        /// </summary>
        [TestMethod()]
        public void Venture_VentureAppointment_Delete()
        {
            var reader = new EntityReader<VentureAppointment>();
            var dbVenture = new VentureAppointment();
            var result = new VentureAppointment();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureAppointment_Create();
            lastKey = VentureAppointmentTests.RecycleBin.LastOrDefault();

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
        public void Venture_VentureAppointment_Serialize()
        {
            var searchChar = "i";
            var originalObject = new VentureAppointment() { AppointmentName = searchChar, AppointmentDescription = searchChar };
            var resultObject = new VentureAppointment();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<VentureAppointment>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.AppointmentName == searchChar);
            Assert.IsTrue(resultObject.AppointmentDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<VentureAppointment>();
            var reader = new EntityReader<VentureAppointment>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
