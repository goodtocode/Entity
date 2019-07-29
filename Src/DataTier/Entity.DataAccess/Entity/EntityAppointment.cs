//-----------------------------------------------------------------------
// <copyright file="EntityAppointment.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extras.Data;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity location and time
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityAppointment : ActiveRecordEntity<EntityAppointment>, IEntityAppointment
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityAppointment> CreateStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@AppointmentKey", AppointmentKey),
                new SqlParameter("@AppointmentName", AppointmentName),                
                new SqlParameter("@AppointmentDescription", AppointmentDescription),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityAppointment> UpdateStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@AppointmentKey", AppointmentKey),
                new SqlParameter("@AppointmentName", AppointmentName),
                new SqlParameter("@AppointmentDescription", AppointmentDescription),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityAppointment> DeleteStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentDelete",
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
        public override IList<IValidationRule<EntityAppointment>> Rules()
        { return new List<IValidationRule<EntityAppointment>>()
            {
                new ValidationRule<EntityAppointment>(x => x.EntityKey != Defaults.Guid, "EntityKey is required"),
                new ValidationRule<EntityAppointment>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// EntityKey
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string EntityName { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string EntityDescription { get; set; } = Defaults.String;

        /// <summary>
        /// AppointmentKey
        /// </summary>
        public Guid AppointmentKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string AppointmentName { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string AppointmentDescription { get; set; } = Defaults.String;

        /// <summary>
        /// BeginDate
        /// </summary>
        public DateTime BeginDate { get; set; } = Defaults.Date;

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; } = Defaults.Date;

        /// <summary>
        /// SlotLocationKey
        /// </summary>
        public Guid SlotLocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// SlotResourceKey
        /// </summary>
        public Guid SlotResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// TimeRangeKey
        /// </summary>
        public Guid TimeRangeKey { get; set; } = Defaults.Guid;
    }
}