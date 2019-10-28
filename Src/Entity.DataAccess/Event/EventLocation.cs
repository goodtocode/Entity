using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventLocation : EntityInfo<EventLocation>, IEventLocation
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventLocation>> Rules()
        {
            return new List<IValidationRule<EventLocation>>()
            {
                new ValidationRule<EventLocation>(x => x.EventKey != Defaults.Guid, "EventKey is required")
            };
        }

        /// <summary>
        /// Event that owns this Location
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Creator of event (required)
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of event (required)
        /// </summary>
        public string EventName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of event
        /// </summary>
        public string EventDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location key
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location type key
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventLocation() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}