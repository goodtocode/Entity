//-----------------------------------------------------------------------
// <copyright file="LocationTimeRecurring.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Schedule;
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Extras.Text.Cleansing;
using Genesys.Framework.Activity;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Genesys.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationTimeRecurring : ActiveRecordEntity<LocationTimeRecurring>, ILocationTimeRecurring
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

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
        /// Commits to database
        /// </summary>
        public new LocationTimeRecurring Save()
        {
            var writer = new StoredProcedureWriter<LocationTimeRecurring>();
            LocationName = new HtmlUnsafeCleanser(LocationName).Cleanse().ToPascalCase();
            LocationDescription = new HtmlUnsafeCleanser(LocationDescription).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return LocationName;
        }
    }
}