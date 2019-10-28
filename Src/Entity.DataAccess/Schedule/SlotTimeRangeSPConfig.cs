using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class SlotTimeRangeSPConfig : StoredProcedureConfiguration<SlotTimeRange>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> CreateStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> UpdateStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDate", Entity.BeginDate),
                new SqlParameter("@EndDate", Entity.EndDate),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotTimeRange> DeleteStoredProcedure
        => new StoredProcedure<SlotTimeRange>()
        {
            StoredProcedureName = "SlotTimeRangeDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}