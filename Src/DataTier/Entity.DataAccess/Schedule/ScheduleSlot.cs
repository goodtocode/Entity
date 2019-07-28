//-----------------------------------------------------------------------
// <copyright file="ScheduleSlot.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class ScheduleSlot : ActiveRecordEntity<ScheduleSlot>, IScheduleSlot
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> CreateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> UpdateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> DeleteStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotDelete",
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
        public override IList<IValidationRule<ScheduleSlot>> Rules()
        {
            return new List<IValidationRule<ScheduleSlot>>()
            {
                new ValidationRule<ScheduleSlot>(x => x.ScheduleKey != Defaults.Guid, "ScheduleKey is required"),
                new ValidationRule<ScheduleSlot>(x => x.SlotKey != Defaults.Guid, "SlotKey is required")
            };
        }

        /// <summary>
        /// Key of the schedule containing this slot
        /// </summary>
        public Guid ScheduleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Key of this slot to be added to the schedule
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;


        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleSlot() : base() { }
    }
}