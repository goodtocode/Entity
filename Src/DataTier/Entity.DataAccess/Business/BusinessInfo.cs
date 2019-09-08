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

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// BusinessInfo DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class BusinessInfo : ActiveRecordEntity<BusinessInfo>, IBusiness
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> CreateStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@TaxNumber", TaxNumber),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> UpdateStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@TaxNumber", TaxNumber),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> DeleteStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoDelete",
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
        public override IList<IValidationRule<BusinessInfo>> Rules()
        { return new List<IValidationRule<BusinessInfo>>()
            {
                new ValidationRule<BusinessInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Tax number
        /// </summary>
        public string TaxNumber { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessInfo()
            : base()
        {
        }

        /// <summary>
        /// Save the entity to the database
        /// </summary>
        public new BusinessInfo Save()
        {
            var writer = new StoredProcedureWriter<BusinessInfo>();
            Name = new HtmlUnsafeCleanser(Name).Cleanse(); // Ensure data does not contain cross site scripting injection HTML/Js/SQL
            return writer.Save(this);
       }
    }
}
