

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Group of Item
    /// </summary>    
    public class ItemGroupDto : ValueDto<ItemGroupDto>, IItemGroup
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// ItemGroupModelId
        /// </summary>
        public Guid ItemGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemGroupDto()
            : base()
        { }
   }
}
