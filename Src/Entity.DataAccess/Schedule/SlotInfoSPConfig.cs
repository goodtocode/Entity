
using GoodToCode.Extensions;

using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>

    public class SlotInfoSPConfig : StoredProcedureConfiguration<SlotInfo>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<SlotInfo> CreateStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoSave",
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
        public override StoredProcedure<SlotInfo> UpdateStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoSave",
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
        public override StoredProcedure<SlotInfo> DeleteStoredProcedure
        => new StoredProcedure<SlotInfo>()
        {
            StoredProcedureName = "SlotInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}