//-----------------------------------------------------------------------
// <copyright file="IResource.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IResourceInfo : IResourceKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string ResourceName { get; set; }

        /// <summary>
        /// ResourceDescription
        /// </summary>
        string ResourceDescription { get; set; }
    }
}
