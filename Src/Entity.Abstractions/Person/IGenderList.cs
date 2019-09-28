
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Customer
    /// </summary>    
    public interface IGenderList
    {
        /// <summary>
        /// FirstName of customer entity
        /// </summary>
        List<Tuple<int, string, string>> Genders { get; }
    }
}