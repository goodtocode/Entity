
using GoodToCode.Entity.Detail;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Detail of an event, like parking, tickets, etc.
    /// </summary>

    public interface IEventDetail : IEventKey, IDetail
    {
    }
}
