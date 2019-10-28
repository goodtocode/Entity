using GoodToCode.Framework.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// EntityPerson
    /// </summary>
    
    public class PersonInfoSPConfig : StoredProcedureConfiguration<PersonInfo>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonInfoSPConfig() : base(new PersonInfo())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity"></param>
        public PersonInfoSPConfig(PersonInfo entity) : base(entity)
        {
        }

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<PersonInfo> CreateStoredProcedure
        => new StoredProcedure<PersonInfo>()
        {
            StoredProcedureName = "PersonInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FirstName", Entity.FirstName),
                new SqlParameter("@MiddleName", Entity.MiddleName),
                new SqlParameter("@LastName", Entity.LastName),
                new SqlParameter("@BirthDate", Entity.BirthDate),
                new SqlParameter("@GenderCode", Entity.GenderCode)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<PersonInfo> UpdateStoredProcedure
        => new StoredProcedure<PersonInfo>()
        {
            StoredProcedureName = "PersonInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@FirstName", Entity.FirstName),
                new SqlParameter("@MiddleName", Entity.MiddleName),
                new SqlParameter("@LastName", Entity.LastName),
                new SqlParameter("@BirthDate", Entity.BirthDate),
                new SqlParameter("@GenderCode", Entity.GenderCode)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<PersonInfo> DeleteStoredProcedure
        => new StoredProcedure<PersonInfo>()
        {
            StoredProcedureName = "PersonInfoDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
            }
        };
    }
}
