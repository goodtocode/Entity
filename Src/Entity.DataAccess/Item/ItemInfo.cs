using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Items
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ItemInfo : EntityInfo<ItemInfo>, IItem
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// ItemTypeId
        /// </summary>
        public Guid ItemTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ItemInfo>> Rules()
        {
            return new List<IValidationRule<ItemInfo>>()
            {
                new ValidationRule<ItemInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemInfo() : base() { }
        
        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}