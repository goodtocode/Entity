using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// ModuleSetting DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), TableName("ModuleSetting")]
    public class ModuleSetting : EntityBase<ModuleSetting>, IModuleSetting
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
    }
}
