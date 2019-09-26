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

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventResource : ActiveRecordEntity<EventResource>, IEventResource
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventResource> CreateStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EventName", EventName),
                new SqlParameter("@EventDescription", EventDescription),
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
        public override StoredProcedure<EventResource> UpdateStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EventName", EventName),
                new SqlParameter("@EventDescription", EventDescription),
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
        public override StoredProcedure<EventResource> DeleteStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceDelete",
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
        public override IList<IValidationRule<EventResource>> Rules()
        {
            return new List<IValidationRule<EventResource>>()
            {
                new ValidationRule<EventResource>(x => x.EventCreatorKey != Defaults.Guid, "EventCreatorKey is required"),
                new ValidationRule<EventResource>(x => x.ResourceName.Length > 0, "ResourceName is required")
            };
        }

        /// <summary>
        /// Event that owns this Resource
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Creator of event (required)
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of event (required)
        /// </summary>
        public string EventName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of event
        /// </summary>
        public string EventDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Resource key
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
        /// Resource type key
        /// </summary>
        public Guid ResourceTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventResource() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new EventResource Save()
        {
            var writer = new StoredProcedureWriter<EventResource>();
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