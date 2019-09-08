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
    public class SlotLocationDto : EntityDto<SlotLocationDto>, ISlotLocation
    {        
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotLocationDto>> Rules()
            { return new List<IValidationRule<SlotLocationDto>>()
            {
                new ValidationRule<SlotLocationDto>(x => x.SlotName.Length > 0, "SlotName is required"),
                new ValidationRule<SlotLocationDto>(x => x.LocationName.Length > 0, "LocationName is required")
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
        /// Location used in this slot
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location Type (forms a unique key with LocationKey)
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotLocationDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}