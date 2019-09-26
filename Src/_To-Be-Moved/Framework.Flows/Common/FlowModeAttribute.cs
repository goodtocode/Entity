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

namespace GoodToCode.Entity.Common
{
    /// <summary>
    /// Mode of a workflow (creating a new entity, etc.)
    /// </summary>

    [AttributeUsage(AttributeTargets.All)]
    public class FlowMode : System.Attribute
    {
        /// <summary>
        /// Attribute value
        /// </summary>
        public FlowModes Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Value</param>
        public FlowMode(FlowModes value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// The modes a workflow supports
    /// </summary>    
    public enum FlowModes
    {
        /// <summary>
        /// Default. Sets workflow to validate and save data
        /// </summary>
        ValidationAndSave = -1,

        /// <summary>
        /// Saves with no validation
        /// </summary>
        SaveOnly = 1,

        /// <summary>
        /// Validates and does not commit any data
        /// </summary>
        ValidationOnly = 2
    }

}
