using GoodToCode.Entity.Item;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityItem
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceItem : EntityBase<ResourceItem>, IItemInfo, IResourceInfo
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceItem>> Rules()
        {
            return new List<IValidationRule<ResourceItem>>()
            {
                new ValidationRule<ResourceItem>(x => x.ResourceName.Length > 0, "ResourceName is required"),
                new ValidationRule<ResourceItem>(x => x.ItemName.Length > 0, "ItemName is required")
            };
        }

        /// <summary>
        /// ResourceKey
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ResourceName
        /// </summary>
        public string ResourceName { get; set; } = Defaults.String;

        /// <summary>
        /// ResourceDescription
        /// </summary>
        public string ResourceDescription { get; set; } = Defaults.String;

        /// <summary>
        /// ItemKey
        /// </summary>
        public Guid ItemKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ItemName
        /// </summary>
        public string ItemName { get; set; } = Defaults.String;

        /// <summary>
        /// ItemDescription
        /// </summary>
        public string ItemDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceItem()
            : base()
        {
        }
    }
}
