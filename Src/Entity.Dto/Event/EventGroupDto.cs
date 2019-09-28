

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    public class EventGroupDto : ValueDto<EventGroupDto>, IEventGroup
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventGroupDto()
            : base()
        { }
    }
}
