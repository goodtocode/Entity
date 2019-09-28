
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Item
{
	/// <summary>
	/// Item Type
	/// </summary>	
	
	public interface IItemType : INameKey
	{
        /// <summary>
        /// ItemGroupId
        /// </summary>
		Guid ItemGroupKey { get; set; }
	}
}
