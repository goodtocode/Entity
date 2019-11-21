using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Value;

namespace GoodToCode.Entity.Location
{
    /// <summary>
    /// Type of Location
    /// </summary>    
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class LocationType : ValueBase<LocationType>, ILocationType
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationType()
            : base()
        { }
    }
}
