
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotTimeRange : ActiveRecordEntity<SlotTimeRange>, ISlotTimeRange
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> CreateStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> UpdateStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@BeginDate", BeginDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@TimeTypeKey", TimeTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> DeleteStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeDelete",
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
        public override IList<IValidationRule<SlotTimeRange>> Rules()
            { return new List<IValidationRule<SlotTimeRange>>()
            {
                new ValidationRule<SlotTimeRange>(x => x.SlotName.Length > 0, "LocationName is required"),
                new ValidationRule<SlotTimeRange>(x => x.BeginDate != Defaults.Date, "BeginDate is required")
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
        /// Slot begin date
        /// </summary>
        public DateTime BeginDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Slot end date
        /// </summary>
        public DateTime EndDate { get; set; } = Defaults.Date;

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
        public SlotTimeRange() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new SlotTimeRange Save()
        {
            var writer = new StoredProcedureWriter<SlotTimeRange>();
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