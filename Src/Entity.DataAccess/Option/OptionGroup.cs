using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// PropertyGroup
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionGroup : ValueBase<OptionGroup>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public OptionGroup() : base()
		{
		}
	}
}
