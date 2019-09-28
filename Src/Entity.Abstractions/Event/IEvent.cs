
using System;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Event
{
	/// <summary>
	/// Event created by a user
	/// </summary>	
	public interface IEvent : IKey, IEventCreatorKey, INameDescription
	{
        /// <summary>
        /// EventGroupId
        /// </summary>
        Guid EventGroupKey { get; set; }

        /// <summary>
        /// EventTypeId
        /// </summary>
        Guid EventTypeKey { get; set; }

        /// <summary>
        /// Slogan
        /// </summary>
        string Slogan { get; set; }
	}
}
