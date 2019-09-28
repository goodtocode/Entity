
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Type of Location
    /// </summary>    
    public class LocationTypeDto : ValueDto<LocationTypeDto>, ILocationType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationTypeDto()
            : base()
        { }
    }
}
