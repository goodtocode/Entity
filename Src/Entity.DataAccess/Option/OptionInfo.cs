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
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// OptionInfo
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionInfo : ActiveRecordValue<OptionInfo>, IOption
	{
        /// <summary>
        /// Grouping of properties
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Full name of the Option
        /// </summary>
        public string FullName { get; set; } = Defaults.String;

        /// <summary>
        /// Option code
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Full code of the Option
        /// </summary>
        public string FullCode { get; set; } = Defaults.String;

        /// <summary>
        /// Option name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public OptionInfo() : base()
		{
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Id</param>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        /// <param name="name">Name</param>
        public OptionInfo(Guid key, Guid OptionGroupKey, string name) : this()
		{
			this.Key = key;
			this.OptionGroupKey = OptionGroupKey;
			this.Name = name;
		}

        /// <summary>
        /// Pulls only properties with a specific groupId
        /// </summary>
        /// <param name="OptionGroupKey">Option Group Key</param>
        public static IQueryable<OptionInfo> GetByGroup(Guid OptionGroupKey)
		{
            var reader = new ValueReader<OptionInfo>();
            var returnValue = reader.GetByWhere(x => x.OptionGroupKey == OptionGroupKey);
			return returnValue;
		}
		
	}
}
