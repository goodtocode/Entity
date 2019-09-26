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
//using GoodToCode.Framework.Worker;
//using GoodToCode.Framework.Session;
//using GoodToCode.Entity.Activity;
//using System.Collections.Generic;

//namespace GoodToCode.Framework.Flow
//{
//    /// <summary>
//    /// Methods to create and execute a Flow
//    /// </summary>
//    public interface IFlowListExecuter<TDataInConcrete> : IList<ICrudflow<TDataInConcrete>>
//    {
//        /// <summary>
//        /// Activity record for this flow
//        /// </summary>
//        IActivityFlow Activity { get; }

//        /// <summary>
//        /// Constructs and performs the initial save of data, before processing
//        /// </summary>
//        /// <param name="context">Device, application, module and user info</param>
//        /// <param name="inputData">Data to process</param>
//        void Create(ISessionContext context, TDataInConcrete inputData);

//        /// <summary>
//        /// Executes the Flow
//        /// </summary>
//        /// <returns></returns>
//        List<WorkerResult> Execute();

//        /// <summary>
//        /// Results of the workflow
//        /// </summary>
//        List<WorkerResult> Results { get; }
//    }
//}
