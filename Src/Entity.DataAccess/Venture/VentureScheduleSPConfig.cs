using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>

    public class VentureScheduleSPConfig : EntityConfiguration<VentureSchedule>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureSchedule> CreateStoredProcedure
        => new StoredProcedure<VentureSchedule>()
        {
            StoredProcedureName = "VentureScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureSchedule> UpdateStoredProcedure
        => new StoredProcedure<VentureSchedule>()
        {
            StoredProcedureName = "VentureScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureSchedule> DeleteStoredProcedure
        => new StoredProcedure<VentureSchedule>()
        {
            StoredProcedureName = "VentureScheduleDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}