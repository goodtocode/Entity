//-----------------------------------------------------------------------
// <copyright file="PersonSearchController.cs" company="GoodToCode">
//      Copyright (c) 2017-2018 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Entity.WebServices
{
    /// <summary>
    /// Searches for Person records    
    /// </summary>
    [Produces("application/json")]
    public class PersonSearchController : Controller
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
        [HttpGet(ControllerRoute + "/{idOrKey}/{firstName}/{lastName}")]
        public IEnumerable<IPerson> Get(string idOrKey = "", string firstName = "", string lastName = "")
        {
            var returnValue = new List<PersonDto>();
            var id = idOrKey.TryParseInt32();
            var key = idOrKey.TryParseGuid();
            var searchResults = PersonInfo.GetByWhere(x => x.FirstName.Contains(firstName) || x.LastName.Contains(lastName) || x.Key == key || x.Id == id).Take(MaxRecords);

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
            var searchResults = PersonInfo.GetByWhere(x => x.FirstName.Contains(data.FirstName) || x.LastName.Contains(data.LastName) || x.BirthDate == data.BirthDate || x.Key == data.Key || x.Id == data.Id).Take(MaxRecords);
            return searchResults;
        }     
    }
}