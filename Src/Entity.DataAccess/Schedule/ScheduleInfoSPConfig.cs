using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>

    public class ScheduleInfoSPConfig : StoredProcedureConfiguration<ScheduleInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleInfo> CreateStoredProcedure
        => new StoredProcedure<ScheduleInfo>()
        {
            StoredProcedureName = "ScheduleInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleInfo> UpdateStoredProcedure
        => new StoredProcedure<ScheduleInfo>()
        {
            StoredProcedureName = "ScheduleInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleInfo> DeleteStoredProcedure
        => new StoredProcedure<ScheduleInfo>()
        {
            StoredProcedureName = "ScheduleInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}