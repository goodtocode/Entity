
using GoodToCode.Extensions;

using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Resource
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceInfo : EntityBase<ResourceInfo>, IResource
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceInfo>> Rules()
            { return new List<IValidationRule<ResourceInfo>>()
            {
                new ValidationRule<ResourceInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }
        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceInfo() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}