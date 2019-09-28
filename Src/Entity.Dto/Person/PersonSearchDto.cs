using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person Search Results
    /// </summary>
    public class PersonSearchDto : PersonDto
    {
        /// <summary>
        /// Search results
        /// </summary>
        public List<PersonDto> Results { get; set; } = new List<PersonDto>();
    }
}