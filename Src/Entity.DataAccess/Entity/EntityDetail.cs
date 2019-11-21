using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity detail
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityDetail : EntityBase<EntityDetail>, IEntityDetail
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityDetail>> Rules()
        {
            return new List<IValidationRule<EntityDetail>>()
            {
                new ValidationRule<EntityDetail>(x => x.DetailTypeKey != Defaults.Guid, "DetailTypeKey is required")
            };
        }

        /// <summary>
        /// EntityId
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

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
        public EntityDetail()
            : base()
        {
        }
    }
}
