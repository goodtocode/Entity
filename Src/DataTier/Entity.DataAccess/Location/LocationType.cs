//-----------------------------------------------------------------------
// <copyright file="LocationType.cs" company="Genesys Source">
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

namespace Genesys.Entity.Location
{
    /// <summary>
    /// Type of Location
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationType : ActiveRecordValue<LocationType>, ILocationType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationType()
            : base()
        { }
    }
}
