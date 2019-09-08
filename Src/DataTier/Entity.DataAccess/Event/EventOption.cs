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
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventOption : ActiveRecordEntity<EventOption>, IEventOption
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> CreateStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> UpdateStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> DeleteStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventOption>> Rules()
        {
            return new List<IValidationRule<EventOption>>()
            { };
        }

        /// <summary>
        /// EventKey
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Option key
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string OptionName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Description
        /// </summary>
        public string OptionDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Gets one Option for the Event
        /// </summary>
        /// <param name="EventKey">App Id to get Options</param>
        public static IQueryable<EventOption> GetByEvent(Guid EventKey)
        {
            var reader = new EntityReader<EventOption>();
            return reader.GetByWhere(x => x.Key == EventKey);
        }
    }
}
