
using System;
using GoodToCode.Framework.Data;
using GoodToCode.Entity.Location;
using GoodToCode.Entity.Schedule;

namespace GoodToCode.Entity.Event
{
	/// <summary>
	/// Event and a location at a time
	/// </summary>	
	
	public interface IAppointment : IKey, IEventKey, ILocationKey, ITimeRange
	{
	}
}
