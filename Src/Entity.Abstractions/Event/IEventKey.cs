
using System;

namespace GoodToCode.Entity.Event
{
	/// <summary>
	/// Event and a location at a time
	/// </summary>		
	public interface IEventKey
	{
        /// <summary>
        /// Event primary key
        /// </summary>
        Guid EventKey { get; set; }
	}
}
