//-----------------------------------------------------------------------
// <copyright file="ProcessTests.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Serialization;
using GoodToCode.Entity.Application;
using GoodToCode.Entity.Person;
using GoodToCode.Framework.Worker;
using GoodToCode.Framework.Session;


namespace GoodToCode.Entity.Process
{
    /// <summary>
    /// Tests for interop process classes
    /// </summary>
    [TestClass()]
    public class ProcessTests
    {
        /// <summary> 
        /// Process_SessionContextKnownType
        /// WorkerParameter has ISessionContext as parameter, but SessionContext is passed in to DataContractJsonSerializer
        ///   Had to add SessionContext as known type
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Process_SessionContextKnownType()
        {
            var Context = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            var Person = new PersonDto() { FirstName = "First", MiddleName = "Middle", LastName = "Last", BirthDate = DateTime.UtcNow.AddYears(-41) };
            var Item2 = new WorkerParameter<PersonDto>() { Context = Context, DataIn = Person };
            var Serializer2 = new JsonSerializer<WorkerParameter<PersonDto>>();
            // Initialize
            var DataToSendSerialized2 = Serializer2.Serialize(Item2);

            // Test Serialization            
            Assert.IsTrue(DataToSendSerialized2 != Defaults.String, "Did not work");
        }

        /// <summary> 
        /// Process_WorkerParameterSerialize
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Process_WorkerParameterSerialize()
        {
            var context = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            var person = new PersonDto() { FirstName = "First", MiddleName = "Middle", LastName = "Last", BirthDate = DateTime.UtcNow.AddYears(-41) };
            var item = new WorkerParameter<PersonDto>() { Context = context, DataIn = person };
            var Serializer = new JsonSerializer<WorkerParameter<PersonDto>>
            {
                // Disable deserialization exceptions, we want mismatches to be empty string
                ThrowException = false
            };

            // Initialize
            // Test Item2 Serialization
            var dataToSendSerialized = Serializer.Serialize(item);
            Assert.IsTrue(dataToSendSerialized != Defaults.String, "Did not work");
            item = Serializer.Deserialize(dataToSendSerialized);
            Assert.IsTrue(item != null, "Did not work.");
        }

        /// <summary>
        /// Person_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Process_WorkerResultSerialize()
        {
            var Item1 = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            var Serializer1 = new JsonSerializer<ISessionContext>();
            var Serializer2 = new JsonSerializer<SessionContext>();

            // Initialize
            // Test Serialization
            var DataToSendSerialized = Serializer1.Serialize(Item1);
            Assert.IsTrue(DataToSendSerialized != Defaults.String, "Did not work");

            // Test Serialization
            DataToSendSerialized = Serializer2.Serialize(Item1);
            Assert.IsTrue(DataToSendSerialized != Defaults.String, "Did not work");
        }
    }
}