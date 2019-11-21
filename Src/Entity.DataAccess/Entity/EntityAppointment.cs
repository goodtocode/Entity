using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity location and time
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityAppointment : EntityBase<EntityAppointment>, IEntityAppointment
    {        
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