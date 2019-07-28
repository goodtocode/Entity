//-----------------------------------------------------------------------
// <copyright file="IFlowInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Application;
using Genesys.Framework.Data;
using Genesys.Framework.Name;

namespace Genesys.Entity.Flow
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
