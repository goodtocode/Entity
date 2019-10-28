using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityPerson
    /// </summary>

    public class ResourcePersonSPConfig : StoredProcedureConfiguration<ResourcePerson>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourcePerson> CreateStoredProcedure
        => new StoredProcedure<ResourcePerson>()
        {
            StoredProcedureName = "ResourcePersonSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FirstName", Entity.FirstName),
                new SqlParameter("@MiddleName", Entity.MiddleName),
                new SqlParameter("@LastName", Entity.LastName),
                new SqlParameter("@BirthDate", Entity.BirthDate),
                new SqlParameter("@GenderCode", Entity.GenderCode),
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourcePerson> UpdateStoredProcedure
        => new StoredProcedure<ResourcePerson>()
        {
            StoredProcedureName = "ResourcePersonSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FirstName", Entity.FirstName),
                new SqlParameter("@MiddleName", Entity.MiddleName),
                new SqlParameter("@LastName", Entity.LastName),
                new SqlParameter("@BirthDate", Entity.BirthDate),
                new SqlParameter("@GenderCode", Entity.GenderCode),
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourcePerson> DeleteStoredProcedure
        => new StoredProcedure<ResourcePerson>()
        {
            StoredProcedureName = "ResourcePersonDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                
            }
        };
    }
}
