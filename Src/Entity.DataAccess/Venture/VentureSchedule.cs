using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureSchedule : EntityBase<VentureSchedule>, IVentureSchedule
    {        
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<VentureSchedule>> Rules()
        {
            return new List<IValidationRule<VentureSchedule>>()
            {
                new ValidationRule<VentureSchedule>(x => x.ScheduleName.Length > 0, "ScheduleName is required")
            };
        }

        /// <summary>
        /// Venture that owns this Schedule
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Venture (required)
        /// </summary>
        public string VentureName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Venture
        /// </summary>
        public string VentureDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule key
        /// </summary>
        public Guid ScheduleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Schedule where the Venture will be held
        /// </summary>
        public string ScheduleName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Schedule where the Venture will be held
        /// </summary>
        public string ScheduleDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule type key
        /// </summary>
        public Guid ScheduleTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureSchedule() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ScheduleName;
        }
    }
}