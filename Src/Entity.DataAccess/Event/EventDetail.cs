using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event detail
    /// </summary>

    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventDetail : EntityInfo<EventDetail>, IEventDetail
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventDetail>> Rules()
        {
            return new List<IValidationRule<EventDetail>>()
            {
                new ValidationRule<EventDetail>(x => x.DetailTypeKey != Defaults.Guid, "DetailTypeKey is required")
            };
        }

        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// DetailTypeId
        /// </summary>
        public Guid DetailTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Detail (Type) Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Detail (Type) Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Detail Data
        /// </summary>
        public string DetailData { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventDetail()
            : base()
        {
        }
    }
}
