
using GoodToCode.Entity.Activity;
using GoodToCode.Framework.Session;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Flow class
    /// </summary>
    public interface IFlowClass : IActivityFlow
    {
        /// <summary>
        /// Context
        /// </summary>
        ISessionContext Context { get; }

        /// <summary>
        /// Activity
        /// </summary>
        IActivityFlow Activity { get; }
    }
}
