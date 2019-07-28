//-----------------------------------------------------------------------
// <copyright file="IVentureId.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity.Venture
{
	/// <summary>
	/// Venture and a location at a time
	/// </summary>		
	public interface IVentureKey
	{
        /// <summary>
        /// Venture primary key
        /// </summary>
        Guid VentureKey { get; set; }
	}
}
