

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRecurring + Location
    /// </summary>    
    public interface ISlotTimeRecurring : ISlotInfo, ITimeRecurring, ITimeTypeKey, ITimeBehavior
    {
    }
}
