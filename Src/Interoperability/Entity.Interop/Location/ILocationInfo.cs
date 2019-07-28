﻿//-----------------------------------------------------------------------
// <copyright file="ILocation.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace Genesys.Entity.Location
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ILocationInfo : ILocationKey
    {
        /// <summary>
        /// LocationName
        /// </summary>
        string LocationName { get; set; }

        /// <summary>
        /// LocationDescription
        /// </summary>
        string LocationDescription { get; set; }
    }
}
