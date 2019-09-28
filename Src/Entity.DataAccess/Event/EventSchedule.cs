
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventSchedule : ActiveRecordEntity<EventSchedule>, IEventSchedule
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventSchedule> CreateStoredProcedure
        => new StoredProcedure<EventSchedule>()
        {
            StoredProcedureName = "EventScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EventName", EventName),
                new SqlParameter("@EventDescription", EventDescription),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@ScheduleName", ScheduleName),
                new SqlParameter("@ScheduleDescription", ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", ScheduleTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventSchedule> UpdateStoredProcedure
        => new StoredProcedure<EventSchedule>()
        {
            StoredProcedureName = "EventScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EventName", EventName),
                new SqlParameter("@EventDescription", EventDescription),
                new SqlParameter("@ScheduleKey", ScheduleKey),
                new SqlParameter("@ScheduleName", ScheduleName),
                new SqlParameter("@ScheduleDescription", ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", ScheduleTypeKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventSchedule> DeleteStoredProcedure
        => new StoredProcedure<EventSchedule>()
        {
            StoredProcedureName = "EventScheduleDelete",
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
        public override IList<IValidationRule<EventSchedule>> Rules()
        {
            return new List<IValidationRule<EventSchedule>>()
            {
                new ValidationRule<EventSchedule>(x => x.EventCreatorKey != Defaults.Guid, "EventCreatorKey is required"),
                new ValidationRule<EventSchedule>(x => x.ScheduleName.Length > 0, "ScheduleName is required")
            };
        }

        /// <summary>
        /// Event that owns this Schedule
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Creator of event (required)
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of event (required)
        /// </summary>
        public string EventName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of event
        /// </summary>
        public string EventDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule key
        /// </summary>
        public Guid ScheduleKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Schedule where the event will be held
        /// </summary>
        public string ScheduleName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Schedule where the event will be held
        /// </summary>
        public string ScheduleDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Schedule type key
        /// </summary>
        public Guid ScheduleTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EventSchedule() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new EventSchedule Save()
        {
            var writer = new StoredProcedureWriter<EventSchedule>();
            ScheduleName = new HtmlUnsafeCleanser(ScheduleName).Cleanse().ToPascalCase();
            ScheduleDescription = new HtmlUnsafeCleanser(ScheduleDescription).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ScheduleName;
        }
    }
}