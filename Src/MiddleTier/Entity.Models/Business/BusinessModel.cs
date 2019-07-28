//-----------------------------------------------------------------------
// <copyright file="BusinessModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Business
{
    /// <summary>
    /// Common object across models and business entity
    /// </summary>
    /// <remarks></remarks>
    
    public class BusinessModel : EntityModel<BusinessModel>, IBusiness
    {
        /// <summary>
        /// Name of business
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Tax number of business
        /// </summary>
        public string TaxNumber { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public BusinessModel()
            : base()
        {
        }
    }
}
