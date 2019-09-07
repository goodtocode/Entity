//-----------------------------------------------------------------------
// <copyright file="EventDetailType.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
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
