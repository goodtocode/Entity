using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Sessionflow. Main activity record for any data committed to the system.
    /// </summary>

    public class ActivitySessionflowSPConfig : StoredProcedureConfiguration<ActivitySessionflow>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivitySessionflow> CreateStoredProcedure
        => new StoredProcedure<ActivitySessionflow>()
        {
            StoredProcedureName = "ActivitySessionflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@SessionflowData", Entity.SessionflowData)

            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivitySessionflow> UpdateStoredProcedure
        => new StoredProcedure<ActivitySessionflow>()
        {
            StoredProcedureName = "ActivitySessionflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@SessionflowData", Entity.SessionflowData)

            }
        };
    }
}