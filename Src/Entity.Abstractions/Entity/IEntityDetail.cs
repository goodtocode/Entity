
using GoodToCode.Entity.Detail;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Detail of an Entity, like parking, tickets, etc.
    /// </summary>
    public interface IEntityDetail : IEntityKey, IDetail
    {
    }
}
