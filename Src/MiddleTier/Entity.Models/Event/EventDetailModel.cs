//-----------------------------------------------------------------------
// <copyright file="EventDetailModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Event
{
    /// <summary>
    /// Flat and thin event model used for view only pages
    /// </summary>
    /// <remarks></remarks>
    public class EventDetailModel : EntityModel<EventDetailModel>, IEventDetail
    {
        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// DetailTypeId
        /// </summary>
        public Guid DetailTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Detail (Type) Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Detail (Type) Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Detail Data
        /// </summary>
        public string DetailData { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public EventDetailModel() : base() { }
    }
}
