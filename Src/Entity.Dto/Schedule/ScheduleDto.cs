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
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Schedule
    /// </summary>
    public class ScheduleDto : EntityDto<ScheduleDto>
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ScheduleDto>> Rules()
            { return new List<IValidationRule<ScheduleDto>>()
            {
                new ValidationRule<ScheduleDto>(x => x.Name.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}