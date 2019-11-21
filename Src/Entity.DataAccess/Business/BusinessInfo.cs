using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System.Collections.Generic;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// BusinessInfo DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class BusinessInfo : EntityBase<BusinessInfo>, IBusiness
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<BusinessInfo>> Rules()
        { return new List<IValidationRule<BusinessInfo>>()
            {
                new ValidationRule<BusinessInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Tax number
        /// </summary>
        public string TaxNumber { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessInfo()
            : base()
        {
        }
    }
}
