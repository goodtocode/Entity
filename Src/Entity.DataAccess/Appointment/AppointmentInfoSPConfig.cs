using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Event location and time
    /// </summary>    

    public class AppointmentInfoSPConfig : StoredProcedureConfiguration<AppointmentInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> CreateStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@SlotLocationKey", Entity.SlotLocationKey),
                new SqlParameter("@SlotResourceKey", Entity.SlotResourceKey),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> UpdateStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@SlotLocationKey", Entity.SlotLocationKey),
                new SqlParameter("@SlotResourceKey", Entity.SlotResourceKey),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<AppointmentInfo> DeleteStoredProcedure
        => new StoredProcedure<AppointmentInfo>()
        {
            StoredProcedureName = "AppointmentInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}