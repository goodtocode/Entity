//-----------------------------------------------------------------------
// <copyright file="IEventId.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity.Event
{
	/// <summary>
	/// Event and a location at a time
	/// </summary>		
	public interface IEventKey
	{
        /// <summary>
        /// Event primary key
        /// </summary>
        Guid EventKey { get; set; }
	}
}
