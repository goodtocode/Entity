//-----------------------------------------------------------------------
// <copyright file="IActivityFlow.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Application;
using GoodToCode.Entity.Flow;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Flow activity that tracks Flow executions
    /// </summary>	
    public interface IActivityFlow : IEntity, IContext, IApplicationKey, IEntityKey, IFlowKey
    {
        /// <summary>
        /// Is this flow blocked by a previous flow or action?
        /// </summary>
        /// <returns></returns>
        bool CanExecute();
	}
}
