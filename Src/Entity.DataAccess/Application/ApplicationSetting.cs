using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Application DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ApplicationSetting : ValueInfo<ApplicationSetting>, IApplicationSetting
	{
        /// <summary>
        /// ApplicationId
        /// </summary>
        public Guid ApplicationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string SettingName { get; set; } = Defaults.String;

        /// <summary>
        /// Setting Id
        /// </summary>
        public Guid SettingKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Setting Type
        /// </summary>
        public Guid SettingTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Module's Setting value
        /// </summary>
        public string SettingValue { get; set; } = Defaults.String;
    }
}
