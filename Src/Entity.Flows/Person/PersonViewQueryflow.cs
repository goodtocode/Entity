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
//
//using GoodToCode.Entity.Common;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// View Person Queryflow
//    ///// </summary>
//    [CLSCompliant(true)]
//    public class PersonViewQueryflow : Queryflow<PersonManager, PersonViewQueryflow, INameKey, NameKey>
//    {
//        /// <summary>
//        /// Unique id of this Query flow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("07079A37-0317-433D-9FDA-E29C42D123CA"); } }

//        /// <summary>
//        /// Does the work of this Query flow
//        /// </summary>        
//        protected override void DoExecute()
//        {
//            ReturnData(PersonInfo.GetByKey(this.DataIn.Key).Serialize());
//        }        
//    }
//}
