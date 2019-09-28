
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person
    /// </summary>        
    public interface IPerson : IGenderCode
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// MiddleName
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// BirthDate
        /// </summary>
        DateTime BirthDate { get; set; }
    }
}
