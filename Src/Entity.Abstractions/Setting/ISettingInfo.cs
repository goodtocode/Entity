
using System;

namespace GoodToCode.Entity.Setting
{
	/// <summary>
	/// Setting Id, name and value
	/// </summary>	
	public interface ISettingInfo : ISettingKey, ISettingTypeKey
	{
        /// <summary>
        /// Value
        /// </summary>
		string SettingValue { get; set; }
    }
}
