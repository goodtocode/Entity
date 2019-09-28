

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Type of Item
    /// </summary>    
    public class ItemTypeDto : ValueDto<ItemTypeDto>, IItemType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// ItemGroupId
        /// </summary>
        public Guid ItemGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemTypeDto()
            : base()
        { }
    }
}
