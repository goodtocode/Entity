using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event detail
    /// </summary>


    public class EventDetailSPConfig : StoredProcedureConfiguration<EventDetail>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> CreateStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> UpdateStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> DeleteStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
