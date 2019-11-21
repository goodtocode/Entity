using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>

    public class SlotResourceSPConfig : EntityConfiguration<SlotResource>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> CreateStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> UpdateStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@SlotKey", Entity.SlotKey),
                new SqlParameter("@SlotName", Entity.SlotName),
                new SqlParameter("@SlotDescription", Entity.SlotDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotResource> DeleteStoredProcedure
        => new StoredProcedure<SlotResource>()
        {
            StoredProcedureName = "SlotResourceDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}