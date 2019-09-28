
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Customer screen model for binding and transport
    /// </summary>
    /// <remarks></remarks>
    public class GenderList : IGenderList
    {        

        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public List<Tuple<int, string, string>> Genders
        {
            get
            {
                return GenderList.GetAll();
            }
        }

        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public static List<Tuple<int, string, string>> GetAll()
        {
            return new List<Tuple<int, string, string>>() { Person.Genders.NotSet, Person.Genders.Male, Person.Genders.Female };
        }
    }
}
