using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// Type of Resource
    /// </summary>    
    public class ResourceTypeDto : ValueDto<ResourceTypeDto>, IResourceType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeDto()
            : base()
        { }
    }
}
