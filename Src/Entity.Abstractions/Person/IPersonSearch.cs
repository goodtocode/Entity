
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person
    /// </summary>        
    public interface IPersonSearch : IPerson
    {
        /// <summary>
        /// Search Results
        /// </summary>
        List<IPerson> Results { get; set; }
    }
}
