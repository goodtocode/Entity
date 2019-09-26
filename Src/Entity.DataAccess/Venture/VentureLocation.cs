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

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureLocation : ActiveRecordEntity<VentureLocation>, IVentureLocation
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> CreateStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@VentureName", VentureName),
                new SqlParameter("@VentureDescription", VentureDescription),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationName", LocationName),
                new SqlParameter("@LocationDescription", LocationDescription),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> UpdateStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@VentureName", VentureName),
                new SqlParameter("@VentureDescription", VentureDescription),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationName", LocationName),
                new SqlParameter("@LocationDescription", LocationDescription),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> DeleteStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationDelete",
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
        public override IList<IValidationRule<VentureLocation>> Rules()
        {
            return new List<IValidationRule<VentureLocation>>()
            {
                new ValidationRule<VentureLocation>(x => x.LocationName.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Venture that owns this Location
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Venture (required)
        /// </summary>
        public string VentureName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Venture
        /// </summary>
        public string VentureDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location key
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the Venture will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the Venture will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location type key
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureLocation() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new VentureLocation Save()
        {
            var writer = new StoredProcedureWriter<VentureLocation>();
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