
using System;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Venture
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
