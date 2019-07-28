//-----------------------------------------------------------------------
// <copyright file="LocationModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using Genesys.Framework.Name;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Genesys.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    public class LocationModel : EntityModel<LocationModel>, INameDescription
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<LocationModel>> Rules()
        {
            return new List<IValidationRule<LocationModel>>()
            {
                new ValidationRule<LocationModel>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}