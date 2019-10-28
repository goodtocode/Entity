using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Events
    /// </summary>

    public class ResourceTimeRecurringSPConfig : StoredProcedureConfiguration<ResourceTimeRecurring>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey),
                new SqlParameter("@ResourceKey", Entity.ResourceKey),
                new SqlParameter("@ResourceName", Entity.ResourceName),
                new SqlParameter("@ResourceDescription", Entity.ResourceDescription)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<ResourceTimeRecurring>()
        {
            StoredProcedureName = "ResourceTimeRecurringDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
   }
}