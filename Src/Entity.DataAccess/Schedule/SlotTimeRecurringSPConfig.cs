using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>

    public class SlotTimeRecurringSPConfig : EntityConfiguration<SlotTimeRecurring>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeCycleKey", Entity.TimeCycleKey),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeCycleKey", Entity.TimeCycleKey),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<SlotTimeRecurring>()
        {
            StoredProcedureName = "SlotTimeRecurringDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}