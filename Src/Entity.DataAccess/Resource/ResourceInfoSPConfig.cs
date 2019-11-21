using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Resource
    /// </summary>
    public class ResourceInfoSPConfig : EntityConfiguration<ResourceInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceInfo> CreateStoredProcedure
        => new StoredProcedure<ResourceInfo>()
        {
            StoredProcedureName = "ResourceInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceInfo> UpdateStoredProcedure
        => new StoredProcedure<ResourceInfo>()
        {
            StoredProcedureName = "ResourceInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceInfo> DeleteStoredProcedure
        => new StoredProcedure<ResourceInfo>()
        {
            StoredProcedureName = "ResourceInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
    }
}