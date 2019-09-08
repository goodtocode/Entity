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
//using GoodToCode.Entity.Common;
//
//using GoodToCode.Framework.Validation;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// Workflow to Create new Person
//    /// </summary>
//    [CLSCompliant(true)]
//    public class PersonUpdateWorkflow : Workflow<PersonManager, PersonUpdateWorkflow, IPerson, PersonInfo>
//    {
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("29EE0791-A757-40B8-A918-3B81C07AC880"); } }

//        /// <summary>
//        /// BR for this workflow
//        /// </summary>
//        protected override void DoValidate()
//        {
//            if (this.DataIn.FirstName == Defaults.String)
//            {
//                Result.FailedRules.Add(new ValidationResult("First Name is required."));
//            }
//            if (this.DataIn.LastName == Defaults.String)
//            {
//                Result.FailedRules.Add(new ValidationResult("Last Name is required."));
//            }
//        }

//        /// <summary>
//        /// Does the work of this workflow
//        /// </summary>
//        protected override void DoExecute()
//        {
//            int returnValue= Defaults.Integer;
//            var newItem = PersonInfo.GetByKey(this.Context.EntityKey);

//            newItem.Fill(this.DataIn);
//            newItem.Save(this.Activity);
//        }
//    }
//}