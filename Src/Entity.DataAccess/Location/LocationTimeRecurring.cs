using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationTimeRecurring : EntityInfo<LocationTimeRecurring>, ILocationTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<LocationTimeRecurring>> Rules()
        {
            return new List<IValidationRule<LocationTimeRecurring>>()
            {
                new ValidationRule<LocationTimeRecurring>(x => x.LocationKey != Defaults.Guid, "LocationKey is required")
            };
        }

        /// <summary>
        /// Location that supports the days
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string LocationName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string LocationDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Location begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Location end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time this location is expressing (open, closed, etc.)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationTimeRecurring() : base() { }
        
        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}