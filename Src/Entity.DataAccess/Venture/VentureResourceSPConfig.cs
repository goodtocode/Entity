using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>

    public class VentureResourceSPConfig : EntityConfiguration<VentureResource>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureResource> CreateStoredProcedure
        => new StoredProcedure<VentureResource>()
        {
            StoredProcedureName = "VentureResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureResource> UpdateStoredProcedure
        => new StoredProcedure<VentureResource>()
        {
            StoredProcedureName = "VentureResourceSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription),
                new SqlParameter("@ResourceTypeKey", Entity.ResourceTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureResource> DeleteStoredProcedure
        => new StoredProcedure<VentureResource>()
        {
            StoredProcedureName = "VentureResourceDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}