using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityItem
    /// </summary>
    public class ResourceItemSPConfig : EntityConfiguration<ResourceItem>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> CreateStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ItemName", Entity.ItemName),
                new SqlParameter("@ItemDescription", Entity.ItemDescription),
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> UpdateStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ItemName", Entity.ItemName),
                new SqlParameter("@ItemDescription", Entity.ItemDescription),
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> DeleteStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
    }
}
