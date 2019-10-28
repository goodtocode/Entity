
using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture DAO
    /// </summary>

    public class VentureOptionSPConfig : StoredProcedureConfiguration<VentureOption>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureOption> CreateStoredProcedure
        => new StoredProcedure<VentureOption>()
        {
            StoredProcedureName = "VentureOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureOption> UpdateStoredProcedure
        => new StoredProcedure<VentureOption>()
        {
            StoredProcedureName = "VentureOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureOption> DeleteStoredProcedure
        => new StoredProcedure<VentureOption>()
        {
            StoredProcedureName = "VentureOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
