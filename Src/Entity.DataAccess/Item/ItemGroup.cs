using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Group of Item
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ItemGroup : ValueBase<ItemGroup>, IItemGroup
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
        public ItemGroup()
            : base()
        { }
   }
}
