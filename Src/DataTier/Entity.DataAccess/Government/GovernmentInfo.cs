//-----------------------------------------------------------------------
// <copyright file="GovernmentInfo.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Government;
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

namespace GoodToCode.Entity.Government
{
    /// <summary>
    /// EntityGovernment
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class GovernmentInfo : ActiveRecordEntity<GovernmentInfo>, IGovernment
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> CreateStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> UpdateStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> DeleteStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoDelete",
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
        public override IList<IValidationRule<GovernmentInfo>> Rules()
        { return new List<IValidationRule<GovernmentInfo>>()
            {
                new ValidationRule<GovernmentInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public GovernmentInfo()
            : base()
        { }

        /// <summary>
        /// Save the entity to the database
        /// </summary>
        public new GovernmentInfo Save(IActivityContext activity)
        {
            var writer = new StoredProcedureWriter<GovernmentInfo>();
            ActivityContextKey = activity.ActivityContextKey;
            Name = new HtmlUnsafeCleanser(Name).Cleanse(); // Ensure data does not contain cross site scripting injection HTML/Js/SQL
            return writer.Save(this);
        }
    }
}
