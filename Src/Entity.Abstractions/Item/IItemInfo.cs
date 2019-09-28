

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IItemInfo : IItemKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string ItemName { get; set; }

        /// <summary>
        /// ItemDescription
        /// </summary>
        string ItemDescription { get; set; }
    }
}
