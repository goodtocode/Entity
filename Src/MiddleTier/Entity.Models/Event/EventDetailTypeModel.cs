//-----------------------------------------------------------------------
// <copyright file="EventDetailType.cs" company="Genesys Source">
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
    /// Event detail type
    /// </summary>    
    public class EventDetailTypeModel : ValueModel<EventDetailTypeModel>
    {
        /// <summary>
        /// This detail does not apply to the exclude Id
        /// </summary>
        public Guid ExcludeEventTypeKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>        
        public EventDetailTypeModel()
            : base()
        {
        }
    }
}
