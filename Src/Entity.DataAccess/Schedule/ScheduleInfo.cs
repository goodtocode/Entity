using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ScheduleInfo : EntityBase<ScheduleInfo>
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ScheduleInfo>> Rules()
            { return new List<IValidationRule<ScheduleInfo>>()
            {
                new ValidationRule<ScheduleInfo>(x => x.Name.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleInfo() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}