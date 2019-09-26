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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodToCode.Extensions;

using GoodToCode.Framework.Repository;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class FlowTests
    {
        [TestMethod()]
        public void Flow_FlowInfo()
        {
            var workflow = new FlowInfo();
            var flowKey = Defaults.Guid;
            var reader = new ValueReader<FlowInfo>();

            workflow = reader.GetAll().FirstOrDefaultSafe();
            Assert.IsTrue(workflow.Key != Defaults.Guid, "FlowInfo didnt work");

            flowKey = reader.GetAll().FirstOrDefaultSafe().Key;
            workflow = reader.GetByKey(flowKey);
            Assert.IsTrue(workflow.Key != Defaults.Guid, "FlowInfo didnt work");
        }
    }
}
