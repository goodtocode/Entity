

using System;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Government
{
    /// <summary>
    /// Common object across models and Government entity
    /// </summary>
    /// <remarks></remarks>
    
    public class GovernmentDto : EntityDto<GovernmentDto>, IGovernment
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// LocationId
        /// </summary>
        public Guid LocationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public GovernmentDto() : base()
        {
        }
    }
}
