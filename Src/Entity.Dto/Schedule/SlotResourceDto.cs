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

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class SlotResourceDto : EntityDto<SlotResourceDto>, ISlotResource
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotResourceDto>> Rules()
        {
            return new List<IValidationRule<SlotResourceDto>>()
            {
                new ValidationRule<SlotResourceDto>(x => x.SlotName.Length > 0, "SlotName is required"),
                new ValidationRule<SlotResourceDto>(x => x.ResourceName.Length > 0, "ResourceName is required")
            };
        }

        /// <summary>
        /// Slot used
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Slot
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Slot
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Resource used in this slot
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
        /// Resource Type (forms a unique key with ResourceKey)
        /// </summary>
        public Guid ResourceTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotResourceDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ResourceName;
        }
    }
}