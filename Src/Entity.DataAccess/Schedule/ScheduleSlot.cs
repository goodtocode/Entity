using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class ScheduleSlot : EntityBase<ScheduleSlot>, IScheduleSlot
    {        
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