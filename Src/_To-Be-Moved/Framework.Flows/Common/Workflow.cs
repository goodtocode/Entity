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
//using System;
//using System.Linq;
//using GoodToCode.Extensions;
//using GoodToCode.Framework.Worker;

//using GoodToCode.Framework.Flow;
//using GoodToCode.Entity.Activity;
//using GoodToCode.Framework.Activity;

//namespace GoodToCode.Entity.Common
//{
//    /// <summary>
//    /// Base class required for all workflows
//    /// </summary>
//    [CLSCompliant(true)]
//    public abstract class Workflow<TManager, TWorkflowClass, TDataInInterface, TDataInConcrete> : FlowExecuter<TManager, TWorkflowClass, TDataInInterface, TDataInConcrete>
//        where TWorkflowClass : Workflow<TManager, TWorkflowClass, TDataInInterface, TDataInConcrete>, new()
//        where TManager : FlowInteropManager<TDataInInterface>, new()
//        where TDataInConcrete : class, TDataInInterface, new()
//    {
//        /// <summary>
//        /// Workflow Activity record associated with executing this workflow via Execute()
//        /// </summary>
//        public override IActivityFlow Activity { get; protected set; } = new ActivityWorkflow();

//        /// <summary>
//        /// Encourage use of Create() method over constructors for this class.
//        /// </summary>
//        protected Workflow() : base()
//        {
//        }

//        /// <summary>
//        /// Validates the Crudflow Business Rules, does not commit any data
//        /// </summary>
//        /// <returns></returns>
//        public IWorkerResult Validate()
//        {
//            var returnData = new WorkerResult();
//            Mode = FlowModes.ValidationOnly;
//            returnData = Execute();
//            Mode = LastMode;
//            return returnData;
//        }

//        /// <summary>
//        /// Does the workflow-specific work.
//        /// </summary>
//        /// <returns></returns>
//        protected abstract void DoValidate();

//        /// <summary>
//        /// Does the basic steps of a workflow. The Process() function does the workflow-specific work.
//        /// </summary>
//        /// <returns></returns>
//        public override WorkerResult Execute()
//        {
//            var returnValue = new WorkerResult();

//            OnFlowBegin();
//            if (this.Activity.CanExecute() == false)
//            {
//                Result.OnFail("This process has already ran, and cant be executed twice.");
//                OnFlowAlreadyDone();
//            }
//            else
//            {
//                try
//                {
//                    Result.OnStart();
//                    if (this.Mode != FlowModes.ValidationOnly && this.Behavior.Contains(FlowBehaviors.NoTracking) == false)
//                    {
//                        Activity.Save();
//                    }
//                    IsFlowDataComplete();
//                    DoValidate();
//                    if (this.Result.FailedRules.Count == 0)
//                    {
//                        if (this.Mode != FlowModes.ValidationOnly)
//                        {
//                            DoExecute();
//                        }
//                        Activity.FlowStepKey = FlowInfo.Steps.Completed;
//                        Result.OnSuccess();
//                    }
//                }
//                catch (System.Exception ex)
//                {
//                    Activity.FlowStepKey = FlowInfo.Steps.FailedUnexpected;
//                    Result.OnFail("An unexpected error occurred.");
//                    ExceptionLogger.Create(ex, typeof(TWorkflowClass),
//                        String.Format("Workflow.Execute(). ItemToProcess: {0} {1}", this.GetType().FullName, this.ToString()));
//#if DEBUG
//                    System.Diagnostics.Debugger.Break();
//#endif
//                }
//                finally
//                {
//                    if (this.Mode != FlowModes.ValidationOnly && this.Behavior.Contains(FlowBehaviors.NoTracking) == false)
//                    {
//                        Activity.Save();
//                    }
//                }
//            }
//            if (this.Result.FailedRules.Count == 0)
//            {
//                OnFlowComplete();
//            }
//            else
//            {
//                OnFlowFailed();
//            }

//            return Result;
//        }
//    }
//}
