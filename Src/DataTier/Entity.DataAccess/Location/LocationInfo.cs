//-----------------------------------------------------------------------
// <copyright file="LocationInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Extras.Text.Cleansing;
using Genesys.Framework.Activity;
using Genesys.Framework.Data;
using Genesys.Framework.Name;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Genesys.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationInfo : ActiveRecordEntity<LocationInfo>, INameDescription
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> CreateStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> UpdateStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> DeleteStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

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
        public override IList<IValidationRule<LocationInfo>> Rules()
        {
            return new List<IValidationRule<LocationInfo>>()
            {
                new ValidationRule<LocationInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationInfo() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new LocationInfo Save()
        {
            var writer = new StoredProcedureWriter<LocationInfo>();
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