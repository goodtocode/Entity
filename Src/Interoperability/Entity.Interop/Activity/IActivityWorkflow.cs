//-----------------------------------------------------------------------
// <copyright file="IActivityWorkflow.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity.Activity
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
