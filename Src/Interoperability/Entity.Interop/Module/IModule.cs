//-----------------------------------------------------------------------
// <copyright file="IModule.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Data;
using Genesys.Framework.Name;

namespace Genesys.Entity.Module
{
	/// <summary>
	/// Module of the framework
	/// </summary>
	public interface IModule : IKey, INameDescription
	{
        /// <summary>
        /// ModuleGroupId
        /// </summary>
		Guid ModuleGroupKey { get; set; }

        /// <summary>
        /// ModuleTypeId
        /// </summary>
		Guid ModuleTypeKey { get; set; }
	}
}
