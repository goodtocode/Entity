using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event location and time
    /// </summary>    
    public class EventAppointmentSPConfig : EntityConfiguration<EventAppointment>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventAppointment> CreateStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@AppointmentKey", Entity.AppointmentKey),
                new SqlParameter("@AppointmentName", Entity.AppointmentName),                
                new SqlParameter("@AppointmentDescription", Entity.AppointmentDescription),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventAppointment> UpdateStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@AppointmentKey", Entity.AppointmentKey),
                new SqlParameter("@AppointmentName", Entity.AppointmentName),
                new SqlParameter("@AppointmentDescription", Entity.AppointmentDescription),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventAppointment> DeleteStoredProcedure
        => new StoredProcedure<EventAppointment>()
        {
            StoredProcedureName = "EventAppointmentDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}