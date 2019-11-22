using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Framework.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.WebServices
{
    /// <summary>
    /// Searches for Person records    
    /// </summary>
    [Produces("application/json")]
    public class PersonSearchController : ControllerBase
    {
        public const string ControllerName = "PersonSearch";
        public const string ControllerRoute = "v4/PersonSearch";
        public const string GetActionText = "Search";
        public const string GetAction = "Get";
        public const string PostAction = "Post";
        public const int MaxRecords = 500;

        /// <summary>
        /// Parameterized HttpGet search, refreshing only the results region
        ///  Path: /PersonSearch/{id}/{firstName}/{lastName}
        ///  Parameters are strings in order to validate, log and handle incorrect values
        ///  Searched as: Contains, OR
        /// </summary>
        /// <param name="id">Int32 - ID to include in search results</param>
        /// <param name="firstName">String - Text to search in first name</param>
        /// <param name="lastName">String - Text to search in the last name field</param>
        /// <returns>Partial view of only the search results region</returns>
        [HttpGet(ControllerRoute + "/{idOrKey}/{firstName}/{lastName}"), Route(ControllerRoute)]
        public IEnumerable<IPerson> Get(string idOrKey = "", string firstName = "", string lastName = "")
        {
            var returnValue = new List<PersonInfo>();
            var id = idOrKey.TryParseInt32();
            var key = idOrKey.TryParseGuid();
            var searchResults = new EntityReader<PersonInfo>().GetByWhere(x => x.FirstName.Contains(firstName) || x.LastName.Contains(lastName) || x.Key == key || x.Id == id).Take(MaxRecords);

            if (searchResults.Any())
                returnValue.FillRange(searchResults);

            return returnValue;
        }

        /// <summary>
        /// Performs a full HttpPost search, accepting search parameters and returning search parameters and results
        /// </summary>
        /// <param name="data">Model of type IPerson with results list</param>
        /// <returns>JSON of search parameters and any found results</returns>
        [HttpPost(ControllerRoute)]
        public IEnumerable<IPerson> Post([FromBody]PersonDto data)
        {
            var searchResults = new EntityReader<PersonInfo>().GetByWhere(x => x.FirstName.Contains(data.FirstName) || x.LastName.Contains(data.LastName) || x.BirthDate == data.BirthDate || x.Key == data.Key || x.Id == data.Id).Take(MaxRecords);
            return searchResults;
        }     
    }
}