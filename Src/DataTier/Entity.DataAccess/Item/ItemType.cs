//-----------------------------------------------------------------------
// <copyright file="ItemType.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using System;
using System.Linq;

namespace Genesys.Entity.Item
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
