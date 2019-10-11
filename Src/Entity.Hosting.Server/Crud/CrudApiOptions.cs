using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// CrudApiOption for Crud Api Endpoint definition
    /// </summary>
    public class CrudApiOptions : List<CrudApiOption> { }

    /// <summary>
    /// CrudApiOption for Crud Api Endpoint definition
    /// </summary>
    public class CrudApiOption
    {
        /// <summary>
        /// Type passing to/from the CrudApi endpoint
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Route of the CrudApi Endpoint
        /// Default is: $"api/{typeof(Type).Name}"
        /// </summary>
        public string Route { get; set; } = $"api/{typeof(Type).Name}";
    }
}