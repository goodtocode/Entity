

using System;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// ModuleSetting Screen and Transport Model
    /// </summary>    
    public class ModuleSettingDto : EntityDto<ModuleSettingDto>
    {
        /// <summary>
        /// ApplicationId
        /// </summary>
        public int ApplicationId { get; set; } = Defaults.Integer;

        /// <summary>
        /// SettingId
        /// </summary>
        public int SettingId { get; set; } = Defaults.Integer;

        /// <summary>
        /// SettingTypeId
        /// </summary>
        public int SettingTypeId { get; set; } = Defaults.Integer;

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; } = Defaults.String;
    }
}
