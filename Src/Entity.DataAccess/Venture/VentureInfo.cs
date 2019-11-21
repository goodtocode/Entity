using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Ventures
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureInfo : EntityBase<VentureInfo>, IVenture
    {
        private readonly string name = Defaults.String;

        /// <summary>
        /// VentureGroupId
        /// </summary>
        public Guid VentureGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// VentureTypeId
        /// </summary>
        public Guid VentureTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<VentureInfo>> Rules()
        {
            return new List<IValidationRule<VentureInfo>>()
            {
                new ValidationRule<VentureInfo>(x => x.Name.Length > 0, "Name is required")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureInfo() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}