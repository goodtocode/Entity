using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture detail
    /// </summary>
    public class VentureDetailSPConfig : EntityConfiguration<VentureDetail>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> CreateStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> UpdateStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@DetailTypeKey", Entity.DetailTypeKey),
                new SqlParameter("@DetailData", Entity.DetailData)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> DeleteStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
