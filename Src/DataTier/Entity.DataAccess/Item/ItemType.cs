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
using System.Linq;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Type of Item
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ItemType : ActiveRecordValue<ItemType>, IItemType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// ItemGroupId
        /// </summary>
        public Guid ItemGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemType()
            : base()
        { }

        /// <summary>
        /// Pulls all Item types for a group
        /// </summary>
        /// <param name="ItemGroupKey">Group to pull</param>        
        public static IQueryable<ItemType> GetByItemGroup(Guid ItemGroupKey)
		{
            var reader = new ValueReader<ItemType>();
			return reader.GetByWhere(x => x.ItemGroupKey == ItemGroupKey 
                              || x.Key == Defaults.Guid).OrderBy(y => y.Name);
		}
    }
}
