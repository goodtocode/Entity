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
//using GoodToCode.Extensions;
//using GoodToCode.Framework.Session;
//using GoodToCode.Entity.Common;
//

//namespace GoodToCode.Entity.Flow
//{
//    /// <summary>
//    /// Create new sessionflow. This record is required to call any other workflow.
//    /// </summary>

//    [CLSCompliant(true), FlowBehavior(FlowBehaviors.Anonymous)]
//    public class SessionflowCreateWorkflow : Workflow<SessionflowCreateManager, SessionflowCreateWorkflow, ISessionContext, SessionContext>
//    {
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("71C39399-6976-4620-9F24-CFC7FFA64B45"); } }

//        /// <summary>
//        /// BR for this workflow
//        /// </summary>
//        protected override void DoValidate()
//        {
//        }

//        /// <summary>
//        /// Does the work of this workflow
//        /// </summary>
//        protected override void DoExecute()
//        {            
//            ActivitySessionflow newItem = new ActivitySessionflow();

//            newItem.Fill(this.Context);
//            newItem.Save(this.Activity);
//            ReturnData(newItem);
//        }
//    }
//}