using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;

using GoodToCode.Framework.Repository;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class OptionTests
    {
        /// <summary>
        /// Contact_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Option_OptionInfo_Get()
        {
            var reader = new ValueReader<OptionInfo>();
            var ItemToTest = new OptionInfo();

            ItemToTest = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(ItemToTest != null, "Item constructed and did not fail.");
        }                
    }
}
