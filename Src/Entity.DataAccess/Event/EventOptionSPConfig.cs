
using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event DAO
    /// </summary>

    public class EventOptionSPConfig : StoredProcedureConfiguration<EventOption>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> CreateStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> UpdateStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventOption> DeleteStoredProcedure
        => new StoredProcedure<EventOption>()
        {
            StoredProcedureName = "EventOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
