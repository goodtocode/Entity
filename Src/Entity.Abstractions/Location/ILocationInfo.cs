

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ILocationInfo : ILocationKey
    {
        /// <summary>
        /// LocationName
        /// </summary>
        string LocationName { get; set; }

        /// <summary>
        /// LocationDescription
        /// </summary>
        string LocationDescription { get; set; }
    }
}
