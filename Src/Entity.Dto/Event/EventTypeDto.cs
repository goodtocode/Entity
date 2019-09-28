
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    public class EventTypeDto : ValueDto<EventTypeDto>, IEventType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// EventGroupId
        /// </summary>
        public Guid EventGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventTypeDto()
            : base()
        { }
    }
}
