
using System;

namespace GoodToCode.Entity.Venture
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
