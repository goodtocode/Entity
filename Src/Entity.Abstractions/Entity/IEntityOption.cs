
using System;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity
{
	/// <summary>
	/// A entity's properties, like gender, social preferences, etc.
	/// </summary>
    public interface IEntityOption : IEntityKey
	{
        /// <summary>
        /// OptionId
        /// </summary>
		Guid OptionKey { get; set; }
	}
}
