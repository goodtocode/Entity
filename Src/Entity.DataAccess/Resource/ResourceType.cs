using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Type of Resource
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceType : ValueBase<ResourceType>, IResourceType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceType()
            : base()
        { }
    }
}
