
using GoodToCode.Extensions;

using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using System;
using System.Linq;

namespace GoodToCode.Entity.Detail
{
    /// <summary>
    ///  detail type
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class DetailType : ActiveRecordValue<DetailType>
    {
        /// <summary>
        /// This detail does not apply to the exclude Id
        /// </summary>
        public Guid ExcludeTypeKey { get; set; } = Defaults.Guid;
        
        /// <summary>
        /// Constructor
        /// </summary>        
        public DetailType()
            : base()
        {
        }

        /// <summary>
        /// Gets all detail types that are not excluded for this  type
        /// </summary>
        public static IQueryable<DetailType> GetByType(Guid TypeKey)
		{
            var reader = new ValueReader<DetailType>();
			return reader.GetByWhere(x => x.ExcludeTypeKey != TypeKey);
		}
    }
}
