using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Government
{
    /// <summary>
    /// EntityGovernment
    /// </summary>

    public class GovernmentInfoSPConfig : StoredProcedureConfiguration<GovernmentInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> CreateStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> UpdateStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<GovernmentInfo> DeleteStoredProcedure
        => new StoredProcedure<GovernmentInfo>()
        {
            StoredProcedureName = "GovernmentInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
