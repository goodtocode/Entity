
using GoodToCode.Extensions;

using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using System;
using System.Linq;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventType : ActiveRecordValue<EventType>, IEventType
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
        public EventType()
            : base()
        { }

        /// <summary>
        /// Pulls all event types for a group
        /// </summary>
        /// <param name="eventGroupKey">Group to pull</param>        
        public static IQueryable<EventType> GetByEventGroup(Guid eventGroupKey)
		{
            var reader = new ValueReader<EventType>();
			return reader.GetByWhere(x => x.EventGroupKey == eventGroupKey 
                              || x.Key == Defaults.Guid).OrderBy(y => y.Name);
		}
    }
}
