//-----------------------------------------------------------------------
// <copyright file="IEvent.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Event
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
