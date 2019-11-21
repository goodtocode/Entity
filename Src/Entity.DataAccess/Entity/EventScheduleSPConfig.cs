using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    public class EntityScheduleSPConfig : EntityConfiguration<EntitySchedule>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> CreateStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@EntityName", Entity.EntityName),
                new SqlParameter("@EntityDescription", Entity.EntityDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> UpdateStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@EntityName", Entity.EntityName),
                new SqlParameter("@EntityDescription", Entity.EntityDescription),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@ScheduleName", Entity.ScheduleName),
                new SqlParameter("@ScheduleDescription", Entity.ScheduleDescription),
                new SqlParameter("@ScheduleTypeKey", Entity.ScheduleTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntitySchedule> DeleteStoredProcedure
        => new StoredProcedure<EntitySchedule>()
        {
            StoredProcedureName = "EntityScheduleDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}