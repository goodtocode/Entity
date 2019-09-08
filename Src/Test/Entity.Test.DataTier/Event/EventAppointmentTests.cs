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
using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event Appointment tests
    /// </summary>
    [TestClass()]
    public class EventAppointmentTests
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

        List<EventAppointment> testEntities = new List<EventAppointment>()
        {
            new EventAppointment() {EventName = "Fall Semester", EventDescription = "Fall semester classes", AppointmentName = "Building Pod A",  AppointmentDescription = "Student Appointment of Classes", BeginDate = DateTime.UtcNow.AddDays(30)},
            new EventAppointment() {EventName = "Spring Semester", EventDescription = "Spring semester classes", AppointmentName = "Building Pod B", AppointmentDescription = "Student Appointment of Classes", BeginDate = DateTime.UtcNow.AddDays(60)},
            new EventAppointment() {EventName = "Newport Practice", EventDescription = "Practice and group in Newport Beach", AppointmentName = "123 Main St, NB, Ca.", AppointmentDescription = "Normal hours of operation", BeginDate = DateTime.UtcNow.AddDays(90)}
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
        /// Event_EventAppointment
        /// </summary>
        [TestMethod()]
        public void Event_EventAppointment_Create()
        {
            var testEntity = new EventAppointment();
            var resultEntity = new EventAppointment();
            var dbEvent = new EventAppointment();
            var reader = new EntityReader<EventAppointment>();
            var testClass = new EventInfoTests();

            // Create event
            testClass.Event_EventInfo_Create();
            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.EventKey = EventInfoTests.RecycleBin.LastOrDefault();
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

            EventAppointmentTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Event_EventAppointment
        /// </summary>
        [TestMethod()]
        public void Event_EventAppointment_Read()
        {
            var reader = new EntityReader<EventAppointment>();
            var dbEvent = new EventAppointment();
            var lastKey = Defaults.Guid;

            Event_EventAppointment_Create();
            lastKey = EventAppointmentTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);
            Assert.IsTrue(dbEvent.CreatedDate.Date == DateTime.UtcNow.Date);
        }

        /// <summary>
        /// Event_EventAppointment
        /// </summary>
        [TestMethod()]
        public void Event_EventAppointment_Update()
        {
            var reader = new EntityReader<EventAppointment>();
            var writer = new StoredProcedureWriter<EventAppointment>();
            var resultEntity = new EventAppointment();
            var dbEvent = new EventAppointment();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Event_EventAppointment_Create();
            lastKey = EventAppointmentTests.RecycleBin.LastOrDefault();

            dbEvent = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = dbEvent.Id;
            originalKey = dbEvent.Key;
            Assert.IsTrue(!dbEvent.IsNew);
            Assert.IsTrue(dbEvent.Id != Defaults.Integer);
            Assert.IsTrue(dbEvent.Key != Defaults.Guid);

            dbEvent.AppointmentName = uniqueValue;
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
        /// Event_EventAppointment
        /// </summary>
        [TestMethod()]
        public void Event_EventAppointment_Delete()
        {
            var reader = new EntityReader<EventAppointment>();
            var dbEvent = new EventAppointment();
            var result = new EventAppointment();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Event_EventAppointment_Create();
            lastKey = EventAppointmentTests.RecycleBin.LastOrDefault();

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
        public void Event_EventAppointment_Serialize()
        {
            var searchChar = "i";
            var originalObject = new EventAppointment() { AppointmentName = searchChar, AppointmentDescription = searchChar };
            var resultObject = new EventAppointment();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<EventAppointment>();

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
            var writer = new StoredProcedureWriter<EventAppointment>();
            var reader = new EntityReader<EventAppointment>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
