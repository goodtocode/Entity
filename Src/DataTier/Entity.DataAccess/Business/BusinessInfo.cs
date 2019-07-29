//-----------------------------------------------------------------------
// <copyright file="BusinessInfo.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extras.Data;
using GoodToCode.Extras.Text.Cleansing;
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
