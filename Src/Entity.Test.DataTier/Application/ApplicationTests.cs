using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public async Task Application_ApplicationInfo()
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
        public async Task Application_Settings()
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
