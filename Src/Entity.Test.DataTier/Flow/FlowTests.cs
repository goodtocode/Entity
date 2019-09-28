using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;

using GoodToCode.Framework.Repository;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class FlowTests
    {
        [TestMethod()]
        public void Flow_FlowInfo()
        {
            var workflow = new FlowInfo();
            var flowKey = Defaults.Guid;
            var reader = new ValueReader<FlowInfo>();

            workflow = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(workflow.Key != Defaults.Guid, "FlowInfo didnt work");

            flowKey = reader.GetAll().FirstOrDefaultSafe().Key;
            workflow = reader.GetByKey(flowKey);
            Assert.IsTrue(workflow.Key != Defaults.Guid, "FlowInfo didnt work");
        }
    }
}
