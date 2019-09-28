using GoodToCode.Entity.Application;
using GoodToCode.Entity.Flow;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
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
    public class ActivityWorkflowTests
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
        public void Activity_ActivityWorkflow_Get()
        {
            var readerActivity = new EntityReader<ActivityWorkflow>();
            var origItem = new ActivityWorkflow();
            var testKey = Defaults.Guid;

            // Create test record
            Activity_ActivityWorkflow_Create();
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
        public void Activity_ActivityWorkflow_Create()
        {
            var readerActivity = new EntityReader<ActivityWorkflow>();
            var readerFlow = new ValueReader<FlowInfo>();
            var readerApp = new ValueReader<ApplicationInfo>();
            var origItem = new ActivityWorkflow();
            var flow = new FlowInfo();
            var applicationKey = Defaults.Guid;
            var entityKey = Defaults.Guid;
            var savedItem = new ActivityWorkflow();

            // Init
            flow = readerFlow.GetAll().FirstOrDefaultSafe();
            applicationKey = readerApp.GetAll().FirstOrDefaultSafe().Key;
            new PersonInfoTests().Person_PersonInfo_Create();
            entityKey = PersonInfoTests.RecycleBin.LastOrDefault();

            //*
            //* Save
            //*
            origItem = new ActivityWorkflow
            {
                ApplicationKey = applicationKey,
                EntityKey = entityKey,
                FlowKey = flow.Key
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

            // Mark for cleanup
            RecycleBin.Add(savedItem.Key);
        }
        
        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public void Activity_ActivityWorkflow_Update()
        {
            var readerActivity = new EntityReader<ActivityWorkflow>();
            var origItem = new ActivityWorkflow();
            var savedItem = new ActivityWorkflow();
            var testKey = Defaults.Guid;

            // Create test record
            Activity_ActivityWorkflow_Create();
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
