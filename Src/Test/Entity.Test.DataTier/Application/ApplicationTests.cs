//-----------------------------------------------------------------------
// <copyright file="ApplicationTest.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
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
