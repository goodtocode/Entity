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

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Items
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ItemInfo : ActiveRecordEntity<ItemInfo>, IItem
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> CreateStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ItemTypeKey", ItemTypeKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> UpdateStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ItemTypeKey", ItemTypeKey),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> DeleteStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// ItemTypeId
        /// </summary>
        public Guid ItemTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ItemInfo>> Rules()
        {
            return new List<IValidationRule<ItemInfo>>()
            {
                new ValidationRule<ItemInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemInfo() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new ItemInfo Save()
        {
            var writer = new StoredProcedureWriter<ItemInfo>();
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