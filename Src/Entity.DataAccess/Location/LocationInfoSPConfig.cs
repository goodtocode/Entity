
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>

    public class LocationInfoSPConfig : StoredProcedureConfiguration<LocationInfo>
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> CreateStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> UpdateStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@Name", Entity.Name),
                new SqlParameter("@Description", Entity.Description)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationInfo> DeleteStoredProcedure
        => new StoredProcedure<LocationInfo>()
        {
            StoredProcedureName = "LocationInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}