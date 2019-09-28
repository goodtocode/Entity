
namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Session flow activity data access object
    /// </summary>    
    public interface IActivityQueryflow : IActivityFlow
    {
        /// <summary>
        /// List of KeyValuePair string items. Properties are Key and Value.
        /// </summary>
        string SqlStatement { get; }
    }
}
