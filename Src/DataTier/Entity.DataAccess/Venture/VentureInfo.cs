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
using System.Linq;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureInfo : ActiveRecordEntity<VentureInfo>, IVenture
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> CreateStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureGroupKey", VentureGroupKey),
                new SqlParameter("@VentureTypeKey", VentureTypeKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Slogan", Slogan),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> UpdateStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureGroupKey", VentureGroupKey),
                new SqlParameter("@VentureTypeKey", VentureTypeKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Slogan", Slogan),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> DeleteStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// VentureGroupId
        /// </summary>
        public Guid VentureGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// VentureTypeId
        /// </summary>
        public Guid VentureTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<VentureInfo>> Rules()
        {
            return new List<IValidationRule<VentureInfo>>()
            {
                new ValidationRule<VentureInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureInfo() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new VentureInfo Save()
        {
            var writer = new StoredProcedureWriter<VentureInfo>();
            Name = new HtmlUnsafeCleanser(Name).Cleanse().ToPascalCase();
            Description = new HtmlUnsafeCleanser(Description).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}