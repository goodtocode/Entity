
using GoodToCode.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Workflow. Main activity record for any data committed to the system.
    /// </summary>

    public class ActivityWorkflowSPConfig : StoredProcedureConfiguration<ActivityWorkflow>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> CreateStoredProcedure
        => new StoredProcedure<ActivityWorkflow>()
        {
            StoredProcedureName = "ActivityWorkflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.Key),
                new SqlParameter("@FlowStepKey", Entity.FlowStepKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> UpdateStoredProcedure
        => new StoredProcedure<ActivityWorkflow>()
        {
            StoredProcedureName = "ActivityWorkflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FlowKey", Entity.FlowKey),
                new SqlParameter("@ApplicationKey", Entity.ApplicationKey),
                new SqlParameter("@EntityKey", Entity.Key),
                new SqlParameter("@FlowStepKey", Entity.FlowStepKey)
                
            }
        };

        /// <summary>
        /// Does not support deletes
        /// </summary>
        public override StoredProcedure<ActivityWorkflow> DeleteStoredProcedure => throw new NotImplementedException();
    }
}
