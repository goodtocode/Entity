

using GoodToCode.Entity.Schedule;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRecurring + Resource
    /// </summary>    
    public interface IResourceTimeRecurring : IResourceInfo, ITimeRecurring, ITimeTypeKey
    {
    }
}
