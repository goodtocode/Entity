
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// OptionModel
    /// </summary>
    public class OptionDto : EntityDto<OptionDto>, IOption
	{
        /// <summary>
        /// Option code
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Option Code Full
        /// </summary>
        public string FullCode { get; set; } = Defaults.String;

        /// <summary>
        /// Option Full Name
        /// </summary>
        public string FullName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Option Group Id
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public OptionDto() 
            : base()
		{
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Id</param>
        /// <param name="optionGroupKey">OptionGroupId</param>
        /// <param name="name">Name</param>
        public OptionDto(Guid key, Guid optionGroupKey, string name) 
            : this()
		{
			this.Key = key;
			this.OptionGroupKey = optionGroupKey;
			this.Name = name;
		}
    }
}
