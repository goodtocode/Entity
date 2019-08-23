//-----------------------------------------------------------------------
// <copyright file="ActivityQueryflowTests.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Application;
using GoodToCode.Entity.Flow;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extras.Configuration;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class ActivityQueryflowTests
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
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public void Activity_ActivityQueryflow_Get()
        {
            var readerActivity = new EntityReader<ActivityQueryflow>();
            var origItem = new ActivityQueryflow();
            var testKey = Defaults.Guid;

            // Create test record
            Activity_ActivityQueryflow_Create();
            testKey = RecycleBin.LastOrDefault();

            // Verify
            origItem = readerActivity.GetByKey(testKey);
            Assert.IsTrue(!origItem.IsNew);
            Assert.IsTrue(origItem.Id != Defaults.Integer);
            Assert.IsTrue(origItem.Key != Defaults.Guid);
            Assert.IsTrue(!origItem.FailedRules.Any());
        }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public void Activity_ActivityQueryflow_Create()
        {
            var readerActivity = new EntityReader<ActivityQueryflow>();
            var readerFlow = new ValueReader<FlowInfo>();
            var readerApp = new ValueReader<ApplicationInfo>();
            var origItem = new ActivityQueryflow();
            var flow = new FlowInfo();
            var applicationKey = Defaults.Guid;
            var entityKey = Defaults.Guid;
            var savedItem = new ActivityQueryflow();

            // Init
            new PersonInfoTests().Person_PersonInfo_Create();
            flow = readerFlow.GetAll().FirstOrDefaultSafe();
            applicationKey = readerApp.GetAll().FirstOrDefaultSafe().Key;            
            entityKey = PersonInfoTests.RecycleBin.LastOrDefault();
            Assert.IsTrue(flow.Key != Defaults.Guid);
            Assert.IsTrue(applicationKey != Defaults.Guid);
            Assert.IsTrue(entityKey != Defaults.Guid);

            //*
            //* Save
            //*
            origItem = new ActivityQueryflow
            {
                EntityKey = entityKey,
                FlowKey = flow.Key,
                ApplicationKey = applicationKey
            };
            savedItem = origItem.Save();
            Assert.IsTrue(!savedItem.IsNew);
            Assert.IsTrue(savedItem.Id != Defaults.Integer);
            Assert.IsTrue(savedItem.Key != Defaults.Guid);
            Assert.IsTrue(!savedItem.FailedRules.Any());

            //*
            //* Verify
            //*
            origItem = readerActivity.GetByKey(origItem.Key);
            Assert.IsTrue(!origItem.IsNew);
            Assert.IsTrue(origItem.Id != Defaults.Integer);
            Assert.IsTrue(origItem.Key != Defaults.Guid);
            Assert.IsTrue(!origItem.FailedRules.Any());

            RecycleBin.Add(origItem.Key);
        }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public void Activity_ActivityQueryflow_Update()
        {
            var readerActivity = new EntityReader<ActivityQueryflow>();
            var origItem = new ActivityQueryflow();
            var savedItem = new ActivityQueryflow();
            var testKey = Defaults.Guid;

            // Create test record
            Activity_ActivityQueryflow_Create();
            testKey = RecycleBin.LastOrDefault();

            // Verify
            origItem = readerActivity.GetByKey(testKey);
            origItem.Save();
            savedItem = readerActivity.GetByKey(testKey);
            Assert.IsTrue(savedItem.Key == origItem.Key);
            Assert.IsTrue(!savedItem.FailedRules.Any());
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            // Object does not support deletes
        }
    }
}
