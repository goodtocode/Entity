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
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Contains workflows and their steps
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class FlowInfo : ActiveRecordValue<FlowInfo>, INameDescription
	{
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Friendly description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Time in seconds, when this flow will timeout and require a new activity record to begin
        /// </summary>
        public int TimeoutInSeconds { get; set; } = Defaults.Integer;
    }
}
