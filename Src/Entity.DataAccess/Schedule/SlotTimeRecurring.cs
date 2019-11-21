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
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotTimeRecurring : EntityBase<SlotTimeRecurring>, ISlotTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotTimeRecurring>> Rules()
            { return new List<IValidationRule<SlotTimeRecurring>>()
            {
                new ValidationRule<SlotTimeRecurring>(x => x.SlotName.Length > 0, "LocationName is required"),
                new ValidationRule<SlotTimeRecurring>(x => x.BeginDay != Defaults.Integer, "BeginDay is required")
            };
        }

        /// <summary>
        /// Key of the slot record that owns the times
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Begin time
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// End time
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeCycleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
        /// </summary>
        public int TimeBehavior { get; set; } = TimeBehaviors.AddTime.Key;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotTimeRecurring() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return SlotName;
        }
    }
}