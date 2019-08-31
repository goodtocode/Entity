//-----------------------------------------------------------------------
// <copyright file="IItem.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IItem : INameDescription
    {
        /// <summary>
        /// Type of item, for filtering and behavior
        /// </summary>
        Guid ItemTypeKey { get; set; }
    }
}
