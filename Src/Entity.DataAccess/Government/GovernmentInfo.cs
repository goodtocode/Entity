using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System.Collections.Generic;

namespace GoodToCode.Entity.Government
{
    /// <summary>
    /// EntityGovernment
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class GovernmentInfo : EntityBase<GovernmentInfo>, IGovernment
    {        
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<GovernmentInfo>> Rules()
        { return new List<IValidationRule<GovernmentInfo>>()
            {
                new ValidationRule<GovernmentInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public GovernmentInfo()
            : base()
        { }
    }
}
