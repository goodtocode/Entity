using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    public class VentureLocationSPConfig : StoredProcedureConfiguration<VentureLocation>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> CreateStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> UpdateStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@VentureKey", Entity.VentureKey),
                new SqlParameter("@VentureName", Entity.VentureName),
                new SqlParameter("@VentureDescription", Entity.VentureDescription),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@LocationName", Entity.LocationName),
                new SqlParameter("@LocationDescription", Entity.LocationDescription),
                new SqlParameter("@LocationTypeKey", Entity.LocationTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureLocation> DeleteStoredProcedure
        => new StoredProcedure<VentureLocation>()
        {
            StoredProcedureName = "VentureLocationDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}