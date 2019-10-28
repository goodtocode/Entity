using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity
{
    /// <summary>
    /// EntityOption 
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class EntityOption : EntityInfo<EntityOption>, IEntityOption
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityOption>> Rules()
        {
            return new List<IValidationRule<EntityOption>>()
            { };
        }

        /// <summary>
        /// EntityId regarding this Option
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

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

        /// <summary>
        /// Option Group key
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityOption() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionKey">OptionId</param>
        /// <param name="entityKey">EntityId</param>
        public EntityOption(Guid entityKey, Guid optionKey)
            : base()
        {
            EntityKey = entityKey;
            OptionKey = optionKey;
        }
    }
}