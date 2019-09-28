
using GoodToCode.Entity.Schedule;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRecurring + Entity
    /// </summary>    
    public interface IEntityTimeRecurring : IEntityKey, ITimeRecurring, ITimeTypeKey
    {
    }
}
