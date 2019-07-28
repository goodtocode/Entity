//-----------------------------------------------------------------------
// <copyright file="SlotTimeRecurring.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Extras.Text.Cleansing;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotTimeRecurring : ActiveRecordEntity<SlotTimeRecurring>, ISlotTimeRecurring
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeCycleKey", TimeCycleKey),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDay", BeginDay),
                new SqlParameter("@EndDay", EndDay),
                new SqlParameter("@BeginTime", BeginTime),
                new SqlParameter("@EndTime", EndTime),
                new SqlParameter("@TimeCycleKey", TimeCycleKey),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringDelete",
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
        public override IList<IValidationRule<SlotTimeRecurring>> Rules()
            { return new List<IValidationRule<SlotTimeRecurring>>()
            {
                new ValidationRule<SlotTimeRecurring>(x => x.SlotName.Length > 0, "LocationName is required"),
                new ValidationRule<SlotTimeRecurring>(x => x.BeginDay != Defaults.Integer, "BeginDay is required")
            };
        }

        /// <summary>
        /// Key of the slot record that owns the times
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Begin time
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// End time
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeCycleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
        /// </summary>
        public int TimeBehavior { get; set; } = TimeBehaviors.AddTime.Key;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotTimeRecurring() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new SlotTimeRecurring Save()
        {
            var writer = new StoredProcedureWriter<SlotTimeRecurring>();
            SlotName = new HtmlUnsafeCleanser(SlotName).Cleanse().ToPascalCase();
            SlotDescription = new HtmlUnsafeCleanser(SlotDescription).Cleanse();
            return writer.Save(this);
        }
        
        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return SlotName;
        }
    }
}