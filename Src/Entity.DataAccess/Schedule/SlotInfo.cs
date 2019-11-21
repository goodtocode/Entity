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
    public class SlotInfo : EntityBase<SlotInfo>, ISlot
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotInfo>> Rules()
            { return new List<IValidationRule<SlotInfo>>()
            {
                new ValidationRule<SlotInfo>(x => x.Name.Length > 0, "LocationName is required")
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
        public SlotInfo() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}