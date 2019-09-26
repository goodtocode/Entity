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
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Events
    /// </summary>
    public class ResourceTimeRecurringDto : EntityDto<ResourceTimeRecurringDto>, IResourceTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceTimeRecurringDto>> Rules()
        {
            return new List<IValidationRule<ResourceTimeRecurringDto>>()
            {
                new ValidationRule<ResourceTimeRecurringDto>(x => x.ResourceName.Length > 0, "ResourceName is required")
            };
        }

        /// <summary>
        /// Key of Resource where the event will be held
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Resource where the event will be held
        /// </summary>
        public string ResourceName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Resource where the event will be held
        /// </summary>
        public string ResourceDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Resource begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Resource end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Key of Resource where the event will be held
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTimeRecurringDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ResourceName;
        }
    }
}