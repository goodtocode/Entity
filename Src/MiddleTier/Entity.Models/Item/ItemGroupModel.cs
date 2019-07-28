//-----------------------------------------------------------------------
// <copyright file="ItemGroupModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using System;

namespace Genesys.Entity.Item
{
    /// <summary>
    /// Group of Item
    /// </summary>    
    public class ItemGroupModel : ValueModel<ItemGroupModel>, IItemGroup
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// ItemGroupModelId
        /// </summary>
        public Guid ItemGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemGroupModel()
            : base()
        { }
   }
}
