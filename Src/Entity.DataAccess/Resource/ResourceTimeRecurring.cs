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
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceTimeRecurring : EntityBase<ResourceTimeRecurring>, IResourceTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ResourceTimeRecurring>> Rules()
        {
            return new List<IValidationRule<ResourceTimeRecurring>>()
            {
                new ValidationRule<ResourceTimeRecurring>(x => x.ResourceName.Length > 0, "ResourceName is required")
            };
        }

        /// <summary>
        /// Key of Resource where the event will be held
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Resource where the event will be held
        /// </summary>
        public string ResourceName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Resource where the event will be held
        /// </summary>
        public string ResourceDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Event + Resource begin date
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Event + Resource end date
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Key of Resource where the event will be held
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTimeRecurring() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public async Task<ResourceTimeRecurring> SaveAsync()
        {

            ResourceName = new HtmlUnsafeCleanser(ResourceName).Cleanse().ToPascalCase();
            ResourceDescription = new HtmlUnsafeCleanser(ResourceDescription).Cleanse();
            using (var writer = new EntityWriter<ResourceTimeRecurring>(this, new ResourceTimeRecurringSPConfig()))
            {
                return await writer.SaveAsync();
            }
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return ResourceName;
        }
    }
}