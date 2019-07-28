//-----------------------------------------------------------------------
// <copyright file="GovernmentModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Government
{
    /// <summary>
    /// Common object across models and Government entity
    /// </summary>
    /// <remarks></remarks>
    
    public class GovernmentModel : EntityModel<GovernmentModel>, IGovernment
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// LocationId
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public GovernmentModel() : base()
        {
        }
    }
}
