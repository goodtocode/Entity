using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>

    public class EventLocationSPConfig : StoredProcedureConfiguration<EventLocation>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventLocation> CreateStoredProcedure
        => new StoredProcedure<EventLocation>()
        {
            StoredProcedureName = "EventLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventLocation> UpdateStoredProcedure
        => new StoredProcedure<EventLocation>()
        {
            StoredProcedureName = "EventLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventLocation> DeleteStoredProcedure
        => new StoredProcedure<EventLocation>()
        {
            StoredProcedureName = "EventLocationDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}