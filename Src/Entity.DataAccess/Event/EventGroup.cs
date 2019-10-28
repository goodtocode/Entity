using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventGroup : ValueInfo<EventGroup>, IEventGroup
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventGroup()
            : base()
        { }
    }
}
