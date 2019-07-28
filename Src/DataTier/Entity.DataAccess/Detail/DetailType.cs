//-----------------------------------------------------------------------
// <copyright file="DetailType.cs" company="Genesys Source">
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

namespace Genesys.Entity.Detail
{
    /// <summary>
    ///  detail type
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class DetailType : ActiveRecordValue<DetailType>
    {
        /// <summary>
        /// This detail does not apply to the exclude Id
        /// </summary>
        public Guid ExcludeTypeKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>        
        public DetailType()
            : base()
        {
        }

        /// <summary>
        /// Gets all detail types that are not excluded for this  type
        /// </summary>
        public static IQueryable<DetailType> GetByType(Guid TypeKey)
		{
            var reader = new ValueReader<DetailType>();
			return reader.GetByWhere(x => x.ExcludeTypeKey != TypeKey);
		}
    }
}
