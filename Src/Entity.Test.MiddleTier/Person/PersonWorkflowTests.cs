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
