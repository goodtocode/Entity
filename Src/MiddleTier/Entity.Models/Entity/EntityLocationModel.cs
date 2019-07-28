//-----------------------------------------------------------------------
// <copyright file="EntityLocationModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Location;
using Genesys.Extensions;
using Genesys.Framework.Data;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;

namespace Genesys.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    public class EntityLocationModel : EntityModel<EntityLocationModel>, IEntityLocation
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityLocationModel>> Rules()
            { return new List<IValidationRule<EntityLocationModel>>()
            {
                new ValidationRule<EntityLocationModel>(x => x.EntityKey != Defaults.Guid, "EntityKey is required"),
                new ValidationRule<EntityLocationModel>(x => x.LocationName.Length > 0, "LocationName is required"),
                new ValidationRule<EntityLocationModel>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
            };
        }

        /// <summary>
        /// Entity that owns this location
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Location Key
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the Entity will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the Entity will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Entity + Location begin date
        /// </summary>
        public DateTime BeginDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Entity + Location end date
        /// </summary>
        public DateTime EndDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityLocationModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}