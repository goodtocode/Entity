using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class VentureEntityOptionTests
    {
        /// <summary>
        /// Contact_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Venture_VentureEntityOption_Get()
        {
            var reader = new EntityReader<VentureEntityOption>();
            var ItemToTest = new VentureEntityOption();

            ItemToTest = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(ItemToTest != null, "Item constructed and did not fail.");
        }
    }
}
