using GoodToCode.Entity.Item;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityItem
    /// </summary>
    public class ResourceItemDto : EntityDto<ResourceItemDto>, IItemInfo, IResourceInfo
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceItemDto>> Rules()
        {
            return new List<IValidationRule<ResourceItemDto>>()
            {
                new ValidationRule<ResourceItemDto>(x => x.ResourceName.Length > 0, "ResourceName is required"),
                new ValidationRule<ResourceItemDto>(x => x.ItemName.Length > 0, "ItemName is required")
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
        public ResourceItemDto()
            : base()
        {
        }
    }
}
