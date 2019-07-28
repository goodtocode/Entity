//-----------------------------------------------------------------------
// <copyright file="PersonWorkflowTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Genesys.Extensions;

using Genesys.Framework.Worker;
using Genesys.Framework.Session;

namespace Genesys.Entity.Person
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class PersonWorkflowTests
    {
        /// <summary>
        /// Person_PersonTests
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public void Workflow_Person_PersonCreateWorkflow()
        {
            //// Initialize
            //var DataIn = new PersonInfo() { FirstName = "FirstTest", MiddleName = "MiddleTest", LastName = "LastTest", BirthDate = new DateTime(1977, 3, 30) };            
            //SessionContext Context = new SessionContext( Environment.MachineName, ApplicationInfo.Applications.Sandbox.ToString(), Environment.UserName);
            //PersonCreateWorkflow Workflow = PersonCreateWorkflow.Construct(Context, DataIn);
            //IWorkerResult Result = new WorkerResult();

            ////
            //// New person submitted to workflow
            ////
            //Result = Workflow.Execute();
            //Assert.IsTrue(Result.FailedRules.Count() == 0, "Did not work.");
            //Assert.IsTrue(PersonInfo.GetByKey(Result.ReturnKey).Id != Defaults.Integer, "Did not work.");
        }                
    }
}
