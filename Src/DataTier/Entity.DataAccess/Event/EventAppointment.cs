//-----------------------------------------------------------------------
// <copyright file="EventAppointment.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
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

namespace Genesys.Entity.Event
{
    /// <summary>
    /// Event location and time
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventAppointment : ActiveRecordEntity<EventAppointment>, IEventAppointment
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventAppointment> CreateStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
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
        public override StoredProcedure<EventAppointment> UpdateStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
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
        public override StoredProcedure<EventAppointment> DeleteStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentDelete",
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
        public override IList<IValidationRule<EventAppointment>> Rules()
        { return new List<IValidationRule<EventAppointment>>()
            {
                new ValidationRule<EventAppointment>(x => x.EventKey != Defaults.Guid, "EventKey is required"),
                new ValidationRule<EventAppointment>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// EventKey
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string EventName { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string EventDescription { get; set; } = Defaults.String;

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