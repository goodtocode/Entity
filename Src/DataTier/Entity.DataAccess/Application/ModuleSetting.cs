//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Setting;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
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
