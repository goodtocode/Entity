
using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// EntityOption 
    /// </summary>

    public class EntityOptionSPConfig : StoredProcedureConfiguration<EntityOption>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> CreateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> UpdateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> DeleteStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}