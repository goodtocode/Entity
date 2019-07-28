//-----------------------------------------------------------------------
// <copyright file="EntityOptionTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Genesys.Extensions;

using Genesys.Framework.Repository;
using Genesys.Entity;

namespace Genesys.Entity
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class EntityOptionTests
    {
        /// <summary>
        /// Contact_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Option_EntityOption_Get()
        {
            var reader = new EntityReader<EntityOption>();
            var ItemToTest = new EntityOption();

            ItemToTest = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(ItemToTest != null, "Item constructed and did not fail.");
        }
    }
}
