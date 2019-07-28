//-----------------------------------------------------------------------
// <copyright file="AppointmentInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Event;
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Activity;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Genesys.Entity.Appointment
{
    /// <summary>
    /// Event location and time
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class AppointmentInfo : ActiveRecordEntity<AppointmentInfo>, IAppointment
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> CreateStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@SlotLocationKey", SlotLocationKey),
                new SqlParameter("@SlotResourceKey", SlotResourceKey),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> UpdateStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@Name", Name),
                new SqlParameter("@Description", Description),
                new SqlParameter("@SlotLocationKey", SlotLocationKey),
                new SqlParameter("@SlotResourceKey", SlotResourceKey),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> DeleteStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoDelete",
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
        public override IList<IValidationRule<AppointmentInfo>> Rules()
        { return new List<IValidationRule<AppointmentInfo>>()
            {
                new ValidationRule<AppointmentInfo>(x => x.Name.Length > 0, "Name is required"),
                new ValidationRule<AppointmentInfo>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

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