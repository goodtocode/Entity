using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class ScheduleSlotSPConfig : EntityConfiguration<ScheduleSlot>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> CreateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@SlotKey", Entity.SlotKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> UpdateStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ScheduleKey", Entity.ScheduleKey),
                new SqlParameter("@SlotKey", Entity.SlotKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ScheduleSlot> DeleteStoredProcedure
        => new StoredProcedure<ScheduleSlot>()
        {
            StoredProcedureName = "ScheduleSlotDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}