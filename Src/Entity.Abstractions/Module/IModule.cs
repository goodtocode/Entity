
using System;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Module
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
