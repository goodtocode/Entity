
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Option
{
	/// <summary>
	/// Option that is selectable for any entity
	/// </summary>
	public interface IOption : INameKey
	{
        /// <summary>
        /// OptionGroupId
        /// </summary>
		Guid OptionGroupKey { get; set; }

        /// <summary>
        /// FullName
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// FullCode
        /// </summary>
        string FullCode { get; set; }
    }
}
