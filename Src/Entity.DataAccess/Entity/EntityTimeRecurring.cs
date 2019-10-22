
using GoodToCode.Entity.Schedule;
using GoodToCode.Extensions;

using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityTimeRecurring : ActiveRecordEntity<EntityTimeRecurring>, IEntityTimeRecurring
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
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
        public override StoredProcedure<EntityTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
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
        public override StoredProcedure<EntityTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringDelete",
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
        public override IList<IValidationRule<EntityTimeRecurring>> Rules()
        {
            return new List<IValidationRule<EntityTimeRecurring>>()
            {
                new ValidationRule<EntityTimeRecurring>(x => x.EntityKey != Defaults.Guid, "EntityKey is required")
            };
        }

        /// <summary>
        /// Entity that supports the days
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Entity begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Entity end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time this Entity is expressing (open, closed, etc.)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityTimeRecurring() : base() { }
    }
}