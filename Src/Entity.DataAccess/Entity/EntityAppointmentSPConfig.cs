using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity location and time
    /// </summary>    
    
    public class EntityAppointmentSPConfig : StoredProcedureConfiguration<EntityAppointment>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityAppointment> CreateStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
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
        public override StoredProcedure<EntityAppointment> UpdateStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
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
        public override StoredProcedure<EntityAppointment> DeleteStoredProcedure
        => new StoredProcedure<EntityAppointment>()
        {
            StoredProcedureName = "EntityAppointmentDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}