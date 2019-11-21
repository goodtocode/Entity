using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Type of Item
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ItemType : ValueBase<ItemType>, IItemType
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
        public ItemType()
            : base()
        { }
    }
}
