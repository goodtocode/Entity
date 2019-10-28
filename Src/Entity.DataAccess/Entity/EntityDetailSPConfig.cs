using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity detail
    /// </summary>


    public class EntityDetailSPConfig : StoredProcedureConfiguration<EntityDetail>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> CreateStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.Key),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)

            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> UpdateStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.Key),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)

            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> DeleteStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)

            }
        };
    }
}
