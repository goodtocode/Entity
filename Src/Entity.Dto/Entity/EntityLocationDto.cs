

using GoodToCode.Entity.Location;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    public class EntityLocationDto : EntityDto<EntityLocationDto>, IEntityLocation
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityLocationDto>> Rules()
            { return new List<IValidationRule<EntityLocationDto>>()
            {
                new ValidationRule<EntityLocationDto>(x => x.EntityKey != Defaults.Guid, "EntityKey is required"),
                new ValidationRule<EntityLocationDto>(x => x.LocationName.Length > 0, "LocationName is required"),
                new ValidationRule<EntityLocationDto>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
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
        public EntityLocationDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}