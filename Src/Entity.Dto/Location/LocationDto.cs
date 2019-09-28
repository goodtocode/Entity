
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    public class LocationDto : EntityDto<LocationDto>, INameDescription
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
        public override IList<IValidationRule<LocationDto>> Rules()
        {
            return new List<IValidationRule<LocationDto>>()
            {
                new ValidationRule<LocationDto>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationDto() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}