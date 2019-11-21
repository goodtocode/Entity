using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Events
    /// </summary>
    public class LocationTimeRecurringSPConfig : EntityConfiguration<LocationTimeRecurring>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@LocationKey", Entity.LocationKey),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<LocationTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<LocationTimeRecurring>()
        {
            StoredProcedureName = "LocationTimeRecurringDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}