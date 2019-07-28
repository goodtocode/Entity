//-----------------------------------------------------------------------
// <copyright file="IEntityId.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity
{
	/// <summary>
	/// Entity and a location at a time
	/// </summary>		
	public interface IEntityKey
	{
        /// <summary>
        /// Entity primary key
        /// </summary>
        Guid EntityKey { get; set; }
	}
}
