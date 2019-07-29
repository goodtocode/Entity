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
using GoodToCode.Extras.Serialization;
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
            // Initialize
            String DataToSendSerialized2 = Defaults.String;
            SessionContext Context = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            PersonModel Person = new PersonModel() { FirstName = "First", MiddleName = "Middle", LastName = "Last", BirthDate = DateTime.UtcNow.AddYears(-41) };
            WorkerParameter<PersonModel> Item2 = new WorkerParameter<PersonModel>() { Context = Context, DataIn = Person };
            ISerializer<WorkerParameter<PersonModel>> Serializer2 = new JsonSerializer<WorkerParameter<PersonModel>>();
            DataToSendSerialized2 = Serializer2.Serialize(Item2);

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
            // Initialize
            String dataToSendSerialized = Defaults.String;
            SessionContext context = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            PersonModel person = new PersonModel() { FirstName = "First", MiddleName = "Middle", LastName = "Last", BirthDate = DateTime.UtcNow.AddYears(-41) };
            WorkerParameter<PersonModel> item = new WorkerParameter<PersonModel>() { Context = context, DataIn = person };
            ISerializer<WorkerParameter<PersonModel>> Serializer = new JsonSerializer<WorkerParameter<PersonModel>>
            {
                // Disable deserialization exceptions, we want mismatches to be empty string
                ThrowException = false
            };

            // Test Item2 Serialization
            dataToSendSerialized = Serializer.Serialize(item);
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
            // Initialize
            String DataToSendSerialized = Defaults.String;
            SessionContext Item1 = new SessionContext(Environment.MachineName, Applications.Sandbox.ToString(), Environment.UserName);
            ISerializer<ISessionContext> Serializer1 = new JsonSerializer<ISessionContext>();
            ISerializer<SessionContext> Serializer2 = new JsonSerializer<SessionContext>();

            // Test Serialization
            DataToSendSerialized = Serializer1.Serialize(Item1);
            Assert.IsTrue(DataToSendSerialized != Defaults.String, "Did not work");

            // Test Serialization
            DataToSendSerialized = Serializer2.Serialize(Item1);
            Assert.IsTrue(DataToSendSerialized != Defaults.String, "Did not work");
        }
    }
}