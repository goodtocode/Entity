
using GoodToCode.Entity.Application;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Combines Model data and Workflow/Queryflow into a WorkflowModel
    /// </summary>
    public interface IFlowInfo : IEntity, IApplicationKey, IModuleKey, IEntityKey, IName
    {
        /// <summary>
        /// Time in seconds, when this flow will timeout and require a new activity record to begin
        /// </summary>
        int TimeoutInSeconds { get; set; }
    }
}
