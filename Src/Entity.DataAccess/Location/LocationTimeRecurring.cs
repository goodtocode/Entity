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
using GoodToCode.Entity.Schedule;
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

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationTimeRecurring : ActiveRecordEntity<LocationTimeRecurring>, ILocationTimeRecurring
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringDelete",
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
        public override IList<IValidationRule<LocationTimeRecurring>> Rules()
        {
            return new List<IValidationRule<LocationTimeRecurring>>()
            {
                new ValidationRule<LocationTimeRecurring>(x => x.LocationKey != Defaults.Guid, "LocationKey is required")
            };
        }

        /// <summary>
        /// Location that supports the days
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
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Location begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Location end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time this location is expressing (open, closed, etc.)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationTimeRecurring() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new LocationTimeRecurring Save()
        {
            var writer = new StoredProcedureWriter<LocationTimeRecurring>();
            LocationName = new HtmlUnsafeCleanser(LocationName).Cleanse().ToPascalCase();
            LocationDescription = new HtmlUnsafeCleanser(LocationDescription).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}