
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Event
{
	/// <summary>
	/// Event Type
	/// </summary>	
	
	public interface IEventType : INameKey
	{
        /// <summary>
        /// EventGroupId
        /// </summary>
		Guid EventGroupKey { get; set; }
	}
}
