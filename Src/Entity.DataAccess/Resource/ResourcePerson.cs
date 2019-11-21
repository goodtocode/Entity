using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityPerson
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourcePerson : EntityBase<ResourcePerson>, IFormattable, IPerson, IEntity
    {        
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourcePerson>> Rules()
        {
            return new List<IValidationRule<ResourcePerson>>()
            {
                new ValidationRule<ResourcePerson>(x => x.FirstName.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// ResourceKey
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// PersonKey
        /// </summary>
        public Guid PersonKey { get; set; } = Defaults.Guid;

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
        public ResourcePerson()
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
        public ResourcePerson(string firstName, string middleName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Save the entity to the database. This method will auto-generate activity tracking.
        /// </summary>
        public async Task<ResourcePerson> SaveAsync()
        {
            // Ensure data does not contain cross site scripting injection HTML/Js/SQL
            FirstName = new HtmlUnsafeCleanser(this.FirstName).Cleanse();
            MiddleName = new HtmlUnsafeCleanser(this.MiddleName).Cleanse();
            LastName = new HtmlUnsafeCleanser(this.LastName).Cleanse();
            using (var writer = new EntityWriter<ResourcePerson>(this, new ResourcePersonSPConfig()))
            {
                return await writer.SaveAsync();
            }
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
