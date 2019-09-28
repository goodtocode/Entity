
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// EntityPerson
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class PersonInfo : ActiveRecordEntity<PersonInfo>, IFormattable, IPerson, IEntity
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<PersonInfo> CreateStoredProcedure
        => new StoredProcedure<PersonInfo>()
        {
            StoredProcedureName = "PersonInfoSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@FirstName", FirstName),
                new SqlParameter("@MiddleName", MiddleName),
                new SqlParameter("@LastName", LastName),
                new SqlParameter("@BirthDate", BirthDate),
                new SqlParameter("@GenderCode", GenderCode),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
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
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@FirstName", FirstName),
                new SqlParameter("@MiddleName", MiddleName),
                new SqlParameter("@LastName", LastName),
                new SqlParameter("@BirthDate", BirthDate),
                new SqlParameter("@GenderCode", GenderCode),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
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
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<PersonInfo>> Rules()
        {
            return new List<IValidationRule<PersonInfo>>()
            {
                new ValidationRule<PersonInfo>(x => x.FirstName.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; } = Defaults.String;

        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; } = Defaults.String;

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; } = Defaults.String;

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Gender Id (ISO/IEC 5218)
        /// </summary>
        public string GenderCode { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonInfo()
            : base()
        {
        }

        /// <summary>
        /// Creates unsaved object with data
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        public PersonInfo(string firstName, string middleName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Save the entity to the database. This method will auto-generate activity tracking.
        /// </summary>
        public new PersonInfo Save()
        {
            var writer = new StoredProcedureWriter<PersonInfo>();
            // Ensure data does not contain cross site scripting injection HTML/Js/SQL
            FirstName = new HtmlUnsafeCleanser(this.FirstName).Cleanse();
            MiddleName = new HtmlUnsafeCleanser(this.MiddleName).Cleanse();
            LastName = new HtmlUnsafeCleanser(this.LastName).Cleanse();
            return writer.Save(this);
        }

        /// <summary>
        /// Concatenates name field into common combinations (lfm, lfMI, fMIl, fl, fml)
        /// </summary>
        /// <param name="format">lfm, lfMI, fMIl, fl, fml</param>
        /// <param name="formatProvider">ICustomFormatter compatible class</param>
        /// <returns>Name field formatted in common combinations (lfm, lfMI, fMIl, fl, fml)</returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                if (formatProvider.GetFormat(this.GetType()) is ICustomFormatter formatter) { return formatter.Format(format, this, formatProvider); }
            }
            switch (format)
            {
                case "lfm": return $"{this.LastName}, {this.FirstName} {this.MiddleName}";
                case "lfMI": return $"{this.LastName}, {this.FirstName} {this.MiddleName}.";
                case "fMIl": return $"{this.FirstName} {this.MiddleName}. {this.LastName}";
                case "fl": return $"{this.FirstName} {this.LastName}";
                case "fml":
                case "G":
                default: return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }
    }
}
