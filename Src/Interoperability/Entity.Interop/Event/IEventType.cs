//-----------------------------------------------------------------------
// <copyright file="IEventType.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Name;

namespace Genesys.Entity.Event
{
	/// <summary>
	/// Event Type
	/// </summary>	
	
	public interface IEventType : INameKey
	{
        /// <summary>
        /// EventGroupId
        /// </summary>
		Guid EventGroupKey { get; set; }
	}
}
