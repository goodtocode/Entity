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
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceTimeRecurring : ActiveRecordEntity<ResourceTimeRecurring>, IResourceTimeRecurring
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ResourceKey", ResourceKey),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ResourceKey", ResourceKey),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringDelete",
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
        public override IList<IValidationRule<ResourceTimeRecurring>> Rules()
        {
            return new List<IValidationRule<ResourceTimeRecurring>>()
            {
                new ValidationRule<ResourceTimeRecurring>(x => x.ResourceName.Length > 0, "ResourceName is required")
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
        public ResourceTimeRecurring() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new ResourceTimeRecurring Save()
        {
            var writer = new StoredProcedureWriter<ResourceTimeRecurring>();
            ResourceName = new HtmlUnsafeCleanser(ResourceName).Cleanse().ToPascalCase();
            ResourceDescription = new HtmlUnsafeCleanser(ResourceDescription).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ResourceName;
        }
    }
}