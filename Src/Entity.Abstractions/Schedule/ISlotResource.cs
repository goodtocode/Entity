
using GoodToCode.Entity.Resource;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A slot in a schedule + Resource
    /// </summary>
    public interface ISlotResource : ISlotKey, IResourceInfo, IResourceTypeKey
    {
    }
}
