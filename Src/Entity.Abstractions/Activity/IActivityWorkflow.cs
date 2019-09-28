
using System;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Session flow activity data access object
    /// </summary>    
    public interface IActivityWorkflow : IActivityFlow
    {
        /// <summary>
        /// FlowStepId
        /// </summary>
		Guid FlowStepKey { get; set; }
    }
}
