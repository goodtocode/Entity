namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IResourceInfo : IResourceKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string ResourceName { get; set; }

        /// <summary>
        /// ResourceDescription
        /// </summary>
        string ResourceDescription { get; set; }
    }
}
