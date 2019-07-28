//-----------------------------------------------------------------------
// <copyright file="EventType.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using System;

namespace Genesys.Entity.Event
{
    /// <summary>
    /// Type of event
    /// </summary>    
    public class EventTypeModel : ValueModel<EventTypeModel>, IEventType
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
        public EventTypeModel()
            : base()
        { }
    }
}
