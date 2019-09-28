
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Item
{
	/// <summary>
	/// Item Group
	/// </summary>	
	
	public interface IItemGroup : INameKey
	{
        /// <summary>
        /// ItemGroupId
        /// </summary>
		Guid ItemGroupKey { get; set; }
	}
}
