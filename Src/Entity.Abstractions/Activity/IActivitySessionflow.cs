
namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Session flow activity data access object
    /// </summary>    
    public interface IActivitySessionflow : IActivityFlow
    {
        /// <summary>
        /// List of KeyValuePair string items. Properties are Key and Value.
        /// </summary>
        string SessionflowData { get; }
    }
}
