using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// BusinessInfo DAO
    /// </summary>

    public class BusinessInfoSPConfig : StoredProcedureConfiguration<BusinessInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> CreateStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@TaxNumber", Entity.TaxNumber)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> UpdateStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@TaxNumber", Entity.TaxNumber)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<BusinessInfo> DeleteStoredProcedure
        => new StoredProcedure<BusinessInfo>()
        {
            StoredProcedureName = "BusinessInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
