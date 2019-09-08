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
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class ScheduleSlot : ActiveRecordEntity<ScheduleSlot>, IScheduleSlot
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> CreateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> UpdateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> DeleteStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ScheduleSlot>> Rules()
        {
            return new List<IValidationRule<ScheduleSlot>>()
            {
                new ValidationRule<ScheduleSlot>(x => x.ScheduleKey != Defaults.Guid, "ScheduleKey is required"),
                new ValidationRule<ScheduleSlot>(x => x.SlotKey != Defaults.Guid, "SlotKey is required")
            };
        }

        /// <summary>
        /// Key of the schedule containing this slot
        /// </summary>
        public Guid ScheduleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Key of this slot to be added to the schedule
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;


        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleSlot() : base() { }
    }
}