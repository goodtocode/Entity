//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;

using GoodToCode.Framework.Worker;
using GoodToCode.Framework.Session;

namespace GoodToCode.Entity.Person
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
