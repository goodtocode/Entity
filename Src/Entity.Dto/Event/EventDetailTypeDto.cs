

using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event detail type
    /// </summary>    
    public class EventDetailTypeDto : ValueDto<EventDetailTypeDto>
    {
        /// <summary>
        /// This detail does not apply to the exclude Id
        /// </summary>
        public Guid ExcludeEventTypeKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>        
        public EventDetailTypeDto()
            : base()
        {
        }
    }
}
