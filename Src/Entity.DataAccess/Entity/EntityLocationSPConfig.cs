using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entitys
    /// </summary>
    public class EntityLocationSPConfig : EntityConfiguration<EntityLocation>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> CreateStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> UpdateStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityLocation> DeleteStoredProcedure
        => new StoredProcedure<EntityLocation>()
        {
            StoredProcedureName = "EntityLocationDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}