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
using GoodToCode.Entity.Resource;
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

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotResource : ActiveRecordEntity<SlotResource>, ISlotResource
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> CreateStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@ResourceKey", ResourceKey),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ResourceTypeKey", ResourceTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> UpdateStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@ResourceKey", ResourceKey),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ResourceTypeKey", ResourceTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> DeleteStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceDelete",
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
        public override IList<IValidationRule<SlotResource>> Rules()
        {
            return new List<IValidationRule<SlotResource>>()
            {
                new ValidationRule<SlotResource>(x => x.SlotName.Length > 0, "SlotName is required"),
                new ValidationRule<SlotResource>(x => x.ResourceName.Length > 0, "ResourceName is required")
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
        public SlotResource() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new SlotResource Save()
        {
            var writer = new StoredProcedureWriter<SlotResource>();
            SlotName = new HtmlUnsafeCleanser(SlotName).Cleanse().ToPascalCase();
            SlotDescription = new HtmlUnsafeCleanser(SlotDescription).Cleanse();
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