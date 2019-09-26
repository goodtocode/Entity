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
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
	public class ApplicationTest
	{
		/// <summary>
		/// Application
		/// </summary>
		/// <remarks></remarks>
		[TestMethod()]
		public void Application_ApplicationInfo()
		{
            var apps = new List<ApplicationInfo>();
            var app = new ApplicationInfo();
            var itemKey = Defaults.Guid;
            var reader = new ValueReader<ApplicationInfo>();
            //
            // Pull all
            //
            apps = reader.GetAll().ToList();
            Assert.IsTrue(apps.Count > 0, "All didnt get from database.");
            //
            // Pull one
            //
            itemKey = apps.FirstOrDefaultSafe().Key;
            app = reader.GetByKey(itemKey);
            Assert.IsTrue(app.Key != Defaults.Guid, "All didnt get from database.");
		}

        /// <summary>
        /// Application
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Application_Settings()
        {
            var Apps = new List<ApplicationSetting>();
            var App = new ApplicationSetting();
            var reader = new ValueReader<ApplicationSetting>();

            //
            // Test GetAll()
            //
            App = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(App != null, "Class constructed and data access did not throw exception.");
        }
		
	}
}
