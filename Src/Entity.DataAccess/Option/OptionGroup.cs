

using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// PropertyGroup
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionGroup : ActiveRecordValue<OptionGroup>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public OptionGroup() : base()
		{
		}
	}
}
