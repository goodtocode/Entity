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
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Items
    /// </summary>
    public class ItemDto : EntityDto<ItemDto>, IItem
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// ItemTypeId
        /// </summary>
        public Guid ItemTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ItemDto>> Rules()
        {
            return new List<IValidationRule<ItemDto>>()
            {
                new ValidationRule<ItemDto>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}