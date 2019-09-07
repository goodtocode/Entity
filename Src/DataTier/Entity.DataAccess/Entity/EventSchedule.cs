//-----------------------------------------------------------------------
// <copyright file="EntitySchedule.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntitySchedule : ActiveRecordEntity<EntitySchedule>, IEntitySchedule
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> CreateStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@EntityName", EntityName),
                new SqlParameter("@EntityDescription", EntityDescription),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@ScheduleName", ScheduleName),
                new SqlParameter("@ScheduleDescription", ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", ScheduleTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> UpdateStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@EntityName", EntityName),
                new SqlParameter("@EntityDescription", EntityDescription),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@ScheduleName", ScheduleName),
                new SqlParameter("@ScheduleDescription", ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", ScheduleTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> DeleteStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleDelete",
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
        public override IList<IValidationRule<EntitySchedule>> Rules()
        {
            return new List<IValidationRule<EntitySchedule>>()
            {
                new ValidationRule<EntitySchedule>(x => x.EntityCreatorKey != Defaults.Guid, "EntityCreatorKey is required"),
                new ValidationRule<EntitySchedule>(x => x.ScheduleName.Length > 0, "ScheduleName is required")
            };
        }

        /// <summary>
        /// Entity that owns this Schedule
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Creator of Entity (required)
        /// </summary>
        public Guid EntityCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Entity (required)
        /// </summary>
        public string EntityName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Entity
        /// </summary>
        public string EntityDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule key
        /// </summary>
        public Guid ScheduleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Schedule where the Entity will be held
        /// </summary>
        public string ScheduleName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Schedule where the Entity will be held
        /// </summary>
        public string ScheduleDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule type key
        /// </summary>
        public Guid ScheduleTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntitySchedule() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new EntitySchedule Save()
        {
            var writer = new StoredProcedureWriter<EntitySchedule>();
            ScheduleName = new HtmlUnsafeCleanser(ScheduleName).Cleanse().ToPascalCase();
            ScheduleDescription = new HtmlUnsafeCleanser(ScheduleDescription).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ScheduleName;
        }
    }
}