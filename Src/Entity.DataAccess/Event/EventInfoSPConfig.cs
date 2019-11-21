using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Events
    /// </summary>

    public class EventInfoSPConfig : EntityConfiguration<EventInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> CreateStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventGroupKey", Entity.EventGroupKey),
                new SqlParameter("@EventTypeKey", Entity.EventTypeKey),
                new SqlParameter("@EventCreatorKey", Entity.EventCreatorKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@Slogan", Entity.Slogan)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> UpdateStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EventGroupKey", Entity.EventGroupKey),
                new SqlParameter("@EventTypeKey", Entity.EventTypeKey),
                new SqlParameter("@EventCreatorKey", Entity.EventCreatorKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@Slogan", Entity.Slogan)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventInfo> DeleteStoredProcedure
        => new StoredProcedure<EventInfo>()
        {
            StoredProcedureName = "EventInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}