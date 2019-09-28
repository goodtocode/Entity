

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Items
    /// </summary>
    public class ItemDto : EntityDto<ItemDto>, IItem
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
        public override IList<IValidationRule<ItemDto>> Rules()
        {
            return new List<IValidationRule<ItemDto>>()
            {
                new ValidationRule<ItemDto>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}