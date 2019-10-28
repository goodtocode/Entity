
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    public class VentureInfoSPConfig : StoredProcedureConfiguration<VentureInfo>
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> CreateStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureGroupKey", Entity.VentureGroupKey),
                new SqlParameter("@VentureTypeKey", Entity.VentureTypeKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@Slogan", Entity.Slogan)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> UpdateStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureGroupKey", Entity.VentureGroupKey),
                new SqlParameter("@VentureTypeKey", Entity.VentureTypeKey),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description),
                new SqlParameter("@Slogan", Entity.Slogan)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureInfo> DeleteStoredProcedure
        => new StoredProcedure<VentureInfo>()
        {
            StoredProcedureName = "VentureInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}