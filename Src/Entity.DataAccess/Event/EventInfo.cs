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
    public class EventInfo : EntityBase<EventInfo>, IEvent
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// EventGroupId
        /// </summary>
        public Guid EventGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// EventTypeId
        /// </summary>
        public Guid EventTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// CreatorId
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventInfo>> Rules()
        {
            return new List<IValidationRule<EventInfo>>()
            {
                new ValidationRule<EventInfo>(x => x.Name.Length > 0, "Name is required"),
                new ValidationRule<EventInfo>(x => x.EventCreatorKey != Defaults.Guid, "CreatorKey is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventInfo() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}