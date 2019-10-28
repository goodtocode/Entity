using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventOption : EntityInfo<EventOption>, IEventOption
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventOption>> Rules()
        {
            return new List<IValidationRule<EventOption>>()
            { };
        }

        /// <summary>
        /// EventKey
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Option key
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string OptionName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Description
        /// </summary>
        public string OptionDescription { get; set; } = Defaults.String;
    }
}
