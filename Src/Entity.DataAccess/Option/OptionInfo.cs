using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Value;
using System;
using System.Linq;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// OptionInfo
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionInfo : ValueInfo<OptionInfo>, IOption
	{
        /// <summary>
        /// Grouping of properties
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Full name of the Option
        /// </summary>
        public string FullName { get; set; } = Defaults.String;

        /// <summary>
        /// Option code
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Full code of the Option
        /// </summary>
        public string FullCode { get; set; } = Defaults.String;

        /// <summary>
        /// Option name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public OptionInfo() : base()
		{
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Id</param>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        /// <param name="name">Name</param>
        public OptionInfo(Guid key, Guid OptionGroupKey, string name) : this()
		{
			this.Key = key;
			this.OptionGroupKey = OptionGroupKey;
			this.Name = name;
		}
	}
}
