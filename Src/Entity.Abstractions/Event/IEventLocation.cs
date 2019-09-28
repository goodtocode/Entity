
using GoodToCode.Entity.Location;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event created by a user
    /// </summary>	
    public interface IEventLocation : IEventInfo, ILocationInfo, ILocationTypeKey
    {        
	}
}