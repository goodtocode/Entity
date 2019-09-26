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
            var reader = new ValueReader<ApplicationSetting>();
            return reader.GetByWhere(x => x.Key == applicationKey);
        }

        /// <summary>
        /// Gets one setting for the application
        /// </summary>
        /// <param name="applicationKey">App Id to get settings</param>
        /// <param name="settingTypeKey">Type of setting</param>
        
        public static ApplicationSetting GetByAll(Guid applicationKey, Guid settingTypeKey)
        {
            var reader = new ValueReader<ApplicationSetting>();
            var returnValue = reader.GetByWhere(x => x.Key == applicationKey & x.SettingTypeKey == settingTypeKey);
            return returnValue.FirstOrDefaultSafe();
        }
	}
}
