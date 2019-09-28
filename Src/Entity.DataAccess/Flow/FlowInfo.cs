
using System;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Contains workflows and their steps
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class FlowInfo : ActiveRecordValue<FlowInfo>, INameDescription
	{
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Friendly description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Time in seconds, when this flow will timeout and require a new activity record to begin
        /// </summary>
        public int TimeoutInSeconds { get; set; } = Defaults.Integer;
    }
}
