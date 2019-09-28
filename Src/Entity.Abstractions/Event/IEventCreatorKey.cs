
using System;

namespace GoodToCode.Entity.Event
{
	/// <summary>
	/// Event and a location at a time
	/// </summary>
	public interface IEventCreatorKey
	{
        /// <summary>
        /// Event primary key
        /// </summary>
        Guid EventCreatorKey { get; set; }
	}
}
