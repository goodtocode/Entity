//-----------------------------------------------------------------------
// <copyright file="IVenture.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Data;
using Genesys.Framework.Name;

namespace Genesys.Entity.Venture
{
	/// <summary>
	/// Venture created by a user
	/// </summary>	
	public interface IVenture : IKey, INameDescription
	{
        /// <summary>
        /// Slogan
        /// </summary>
        string Slogan { get; set; }
	}
}
