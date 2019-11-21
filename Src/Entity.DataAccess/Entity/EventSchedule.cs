using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntitySchedule : EntityBase<EntitySchedule>, IEntitySchedule
    {
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
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ScheduleName;
        }
    }
}