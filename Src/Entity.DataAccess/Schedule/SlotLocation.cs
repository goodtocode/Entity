
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class SlotLocation : ActiveRecordEntity<SlotLocation>, ISlotLocation
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> CreateStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationName", LocationName),
                new SqlParameter("@LocationDescription", LocationDescription),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> UpdateStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@SlotKey", SlotKey),
                new SqlParameter("@SlotName", SlotName),
                new SqlParameter("@SlotDescription", SlotDescription),
                new SqlParameter("@LocationKey", LocationKey),
                new SqlParameter("@LocationName", LocationName),
                new SqlParameter("@LocationDescription", LocationDescription),
                new SqlParameter("@LocationTypeKey", LocationTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> DeleteStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationDelete",
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
        public override IList<IValidationRule<SlotLocation>> Rules()
            { return new List<IValidationRule<SlotLocation>>()
            {
                new ValidationRule<SlotLocation>(x => x.SlotName.Length > 0, "SlotName is required"),
                new ValidationRule<SlotLocation>(x => x.LocationName.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Slot used
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Slot
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Slot
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Location used in this slot
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
        /// Location Type (forms a unique key with LocationKey)
        /// </summary>
        public Guid LocationTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotLocation() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new SlotLocation Save()
        {
            var writer = new StoredProcedureWriter<SlotLocation>();
            SlotName = new HtmlUnsafeCleanser(SlotName).Cleanse().ToPascalCase();
            SlotDescription = new HtmlUnsafeCleanser(SlotDescription).Cleanse();
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