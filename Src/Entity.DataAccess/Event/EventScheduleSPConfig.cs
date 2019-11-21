using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>

    public class EventScheduleSPConfig : EntityConfiguration<EventSchedule>
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
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey),
                
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
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey),
                
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
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
   }
}