
using GoodToCode.Entity.Setting;
using GoodToCode.Extensions;

using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// ModuleSetting DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), TableName("ModuleSetting")]
    public class ModuleSetting : EntityInfo<ModuleSetting>, IModuleSetting
	{
        /// <summary>
        /// ModuleKey
        /// </summary>
        public Guid ModuleKey { get; set; } = Defaults.Guid;

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
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ModuleSetting>> Rules()
        { return new List<IValidationRule<ModuleSetting>>()
            {
                new ValidationRule<ModuleSetting>(x => x.SettingName.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Gets one setting for the Module
        /// </summary>
        /// <param name="moduleKey">Id to get</param>
        public static IQueryable<ModuleSetting> GetById(Guid moduleKey)
        {
            return GetByModule(moduleKey);
        }

        /// <summary>
        /// Gets one setting for the Module
        /// </summary>
        /// <param name="moduleKey">Id to get</param>
        public static IQueryable<ModuleSetting>GetByModule(Guid moduleKey)
        {
            using (var reader = new EntityReader<ModuleSetting>())
            {
                var returnValue = reader.GetByWhere(x => x.Key == moduleKey);
                return returnValue;
            }            
        }

        /// <summary>
        /// Gets one setting for the Module
        /// </summary>
        /// <param name="moduleKey">Id to get</param>
        /// <param name="settingTypeKey">Setting type</param>

        public static ModuleSetting GetByAll(Guid moduleKey, Guid settingTypeKey)
        {
            using (var reader = new EntityReader<ModuleSetting>())
            {
                var returnValue = reader.GetByWhere(x => x.Key == moduleKey & x.SettingKey == settingTypeKey);
                return returnValue.FirstOrDefaultSafe();
            }
        }
    }
}
