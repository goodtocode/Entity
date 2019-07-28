//-----------------------------------------------------------------------
// <copyright file="IEvent.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Data;
using Genesys.Framework.Name;

namespace Genesys.Entity.Event
{
	/// <summary>
	/// Event created by a user
	/// </summary>	
	public interface IEvent : IKey, IEventCreatorKey, INameDescription
	{
        /// <summary>
        /// EventGroupId
        /// </summary>
        Guid EventGroupKey { get; set; }

        /// <summary>
        /// EventTypeId
        /// </summary>
        Guid EventTypeKey { get; set; }

        /// <summary>
        /// Slogan
        /// </summary>
        string Slogan { get; set; }
	}
}
