
using System;

namespace GoodToCode.Entity
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
