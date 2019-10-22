
using GoodToCode.Extensions;

using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
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