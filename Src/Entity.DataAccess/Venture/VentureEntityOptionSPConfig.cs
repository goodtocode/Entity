
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// VentureEntity DAO
    /// </summary>
    public class VentureEntityOptionSPConfig : EntityConfiguration<VentureEntityOption>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> CreateStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> UpdateStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> DeleteStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Id", Entity.Id)
                
            }
        };
    }
}
