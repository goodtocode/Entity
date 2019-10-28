using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>

    public class EventResourceSPConfig : StoredProcedureConfiguration<EventResource>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventResource> CreateStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventResource> UpdateStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EventName", Entity.EventName),
                new SqlParameter("@EventDescription", Entity.EventDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventResource> DeleteStoredProcedure
        => new StoredProcedure<EventResource>()
        {
            StoredProcedureName = "EventResourceDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}