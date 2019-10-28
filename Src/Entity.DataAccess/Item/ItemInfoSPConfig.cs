using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Item
{
    /// <summary>
    /// Items
    /// </summary>

    public class ItemInfoSPConfig : StoredProcedureConfiguration<ItemInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> CreateStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ItemTypeKey", Entity.ItemTypeKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> UpdateStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@ItemTypeKey", Entity.ItemTypeKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ItemInfo> DeleteStoredProcedure
        => new StoredProcedure<ItemInfo>()
        {
            StoredProcedureName = "ItemInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
   }
}