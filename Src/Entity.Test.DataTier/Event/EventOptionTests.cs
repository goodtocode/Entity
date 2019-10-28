using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class EventOptionTests
    {
        /// <summary>
        /// Contact_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Event_EventOption_Get()
        {
            var reader = new EntityReader<EventOption>();
            var ItemToTest = new EventOption();

            ItemToTest = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(ItemToTest != null, "Item constructed and did not fail.");
        }
    }
}
