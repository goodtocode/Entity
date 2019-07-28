//-----------------------------------------------------------------------
// <copyright file="EntityLocation.cs" company="Genesys Source">
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
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Genesys.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityLocation : ActiveRecordEntity<EntityLocation>, IEntityLocation
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> CreateStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> UpdateStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> DeleteStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationDelete",
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
        public override IList<IValidationRule<EntityLocation>> Rules()
        {
            return new List<IValidationRule<EntityLocation>>()
            {
                new ValidationRule<EntityLocation>(x => x.EntityKey != Defaults.Guid, "EntityKey is required"),
                new ValidationRule<EntityLocation>(x => x.LocationKey != Defaults.Guid, "LocationKey is required")
            };
        }

        /// <summary>
        /// Entity that owns this Location
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Location key
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the Entity will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the Entity will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location type key
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityLocation() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new EntityLocation Save()
        {
            var writer = new StoredProcedureWriter<EntityLocation>();
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