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
    public class SlotTimeRangeDto : EntityDto<SlotTimeRangeDto>, ISlotTimeRange
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotTimeRangeDto>> Rules()
            { return new List<IValidationRule<SlotTimeRangeDto>>()
            {
                new ValidationRule<SlotTimeRangeDto>(x => x.SlotName.Length > 0, "LocationName is required"),
                new ValidationRule<SlotTimeRangeDto>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// Key of the slot record that owns the times
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Slot begin date
        /// </summary>
        public DateTime BeginDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Slot end date
        /// </summary>
        public DateTime EndDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
        /// </summary>
        public int TimeBehavior { get; set; } = TimeBehaviors.AddTime.Key;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotTimeRangeDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return SlotName;
        }
    }
}