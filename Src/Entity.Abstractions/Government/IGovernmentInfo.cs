
using GoodToCode.Entity.Location;

namespace GoodToCode.Entity.Government
{
    /// <summary>
    /// Government record
    /// </summary>
    public interface IGovernmentInfo : IGovernmentKey, ILocationKey
    {
        /// <summary>
        /// Government Name
        /// </summary>
        string GovernmentName { get; set; }
    }
}
