using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture location and time
    /// </summary>    
    public class VentureAppointmentSPConfig : EntityConfiguration<VentureAppointment>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureAppointment> CreateStoredProcedure
        => new StoredProcedure<VentureAppointment>()
        {
            StoredProcedureName = "VentureAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
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
        public override StoredProcedure<VentureAppointment> UpdateStoredProcedure
        => new StoredProcedure<VentureAppointment>()
        {
            StoredProcedureName = "VentureAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
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
        public override StoredProcedure<VentureAppointment> DeleteStoredProcedure
        => new StoredProcedure<VentureAppointment>()
        {
            StoredProcedureName = "VentureAppointmentDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}