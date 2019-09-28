
using GoodToCode.Entity.Setting;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using System;
using System.Linq;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Application DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ApplicationSetting : ActiveRecordValue<ApplicationSetting>, IApplicationSetting
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

        /// <summary>
        /// Gets one setting for the application
        /// </summary>
        /// <param name="applicationKey">App Id to get settings</param>
        public static IQueryable<ApplicationSetting>GetByApplication(Guid applicationKey)
        {
            using (var reader = new ValueReader<ApplicationSetting>())
            {
                return reader.GetByWhere(x => x.Key == applicationKey);
            }
        }

        /// <summary>
        /// Gets one setting for the application
        /// </summary>
        /// <param name="applicationKey">App Id to get settings</param>
        /// <param name="settingTypeKey">Type of setting</param>

        public static ApplicationSetting GetByAll(Guid applicationKey, Guid settingTypeKey)
        {
            using (var reader = new ValueReader<ApplicationSetting>())
            {
                var returnValue = reader.GetByWhere(x => x.Key == applicationKey & x.SettingTypeKey == settingTypeKey);
                return returnValue.FirstOrDefaultSafe();
            }            
        }
    }
}
