
using GoodToCode.Entity.Schedule;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRecurring + Location
    /// </summary>    
    public interface ILocationTimeRecurring : ILocationInfo, ITimeRecurring, ITimeTypeKey
    {
    }
}
