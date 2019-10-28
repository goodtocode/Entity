
using GoodToCode.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Queryflow. Main activity record for any data committed to the system.
    /// </summary>
    public class ActivityQueryflowSPConfig : StoredProcedureConfiguration<ActivityQueryflow>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> CreateStoredProcedure
        => new StoredProcedure<ActivityQueryflow>()
        {
            StoredProcedureName = "ActivityQueryflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@SqlStatement", Entity.SqlStatement)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> UpdateStoredProcedure
        => new StoredProcedure<ActivityQueryflow>()
        {
            StoredProcedureName = "ActivityQueryflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@SqlStatement", Entity.SqlStatement)
                
            }
        };

        /// <summary>
        /// Does not support deletes
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> DeleteStoredProcedure => throw new NotImplementedException();
    }
}
