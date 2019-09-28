
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRange + Location
    /// </summary>    
    public interface ISlotTimeRange : ISlotKey, ITimeRange, ITimeTypeKey, ITimeBehavior
    {
    }
}
