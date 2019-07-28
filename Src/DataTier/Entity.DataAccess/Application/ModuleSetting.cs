//-----------------------------------------------------------------------
// <copyright file="ModuleSetting.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Setting;
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genesys.Entity.Application
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
            var reader = new EntityReader<ModuleSetting>();
            var returnValue = reader.GetByWhere(x => x.Key == moduleKey);
            return returnValue;
        }

        /// <summary>
        /// Gets one setting for the Module
        /// </summary>
        /// <param name="moduleKey">Id to get</param>
        /// <param name="settingTypeKey">Setting type</param>
        
        public static ModuleSetting GetByAll(Guid moduleKey, Guid settingTypeKey)
        {
            var reader = new EntityReader<ModuleSetting>();
            var returnValue = reader.GetByWhere(x => x.Key == moduleKey & x.SettingKey == settingTypeKey);
            return returnValue.FirstOrDefaultSafe();
        }
	}
}
