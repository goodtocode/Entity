//-----------------------------------------------------------------------
// <copyright file="EventType.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using System;
using System.Linq;

namespace Genesys.Entity.Event
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
