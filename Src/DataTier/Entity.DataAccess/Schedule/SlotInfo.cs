//-----------------------------------------------------------------------
// <copyright file="SlotInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Extras.Text.Cleansing;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotInfo : ActiveRecordEntity<SlotInfo>, ISlot
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotInfo> CreateStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoSave",
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
        public override StoredProcedure<SlotInfo> UpdateStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoSave",
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
        public override StoredProcedure<SlotInfo> DeleteStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoDelete",
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
        public override IList<IValidationRule<SlotInfo>> Rules()
            { return new List<IValidationRule<SlotInfo>>()
            {
                new ValidationRule<SlotInfo>(x => x.Name.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotInfo() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new SlotInfo Save()
        {
            var writer = new StoredProcedureWriter<SlotInfo>();
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