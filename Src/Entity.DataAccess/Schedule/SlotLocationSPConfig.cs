using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Time Slot and Location
    /// </summary>
    public class SlotLocationSPConfig : StoredProcedureConfiguration<SlotLocation>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> CreateStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> UpdateStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotLocation> DeleteStoredProcedure
        => new StoredProcedure<SlotLocation>()
        {
            StoredProcedureName = "SlotLocationDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}