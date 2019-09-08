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
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// OptionModel
    /// </summary>
    public class OptionDto : EntityDto<OptionDto>, IOption
	{
        /// <summary>
        /// Option code
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Option Code Full
        /// </summary>
        public string FullCode { get; set; } = Defaults.String;

        /// <summary>
        /// Option Full Name
        /// </summary>
        public string FullName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Option Group Id
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public OptionDto() 
            : base()
		{
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Id</param>
        /// <param name="optionGroupKey">OptionGroupId</param>
        /// <param name="name">Name</param>
        public OptionDto(Guid key, Guid optionGroupKey, string name) 
            : this()
		{
			this.Key = key;
			this.OptionGroupKey = optionGroupKey;
			this.Name = name;
		}
    }
}
