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
using GoodToCode.Extensions;
using GoodToCode.Entity.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Creates a Person
    /// </summary>
    [Authorize]
    public class PersonSearchController : Controller
    {
        public const string ControllerName = "PersonSearch";
        public const string SearchAction = "Search";
        public const string SearchActionText = SearchAction;
        public const string SearchView = "~/Pages/PersonSearch/PersonSearch.cshtml";
        public const string SearchResultsAction = "SearchResults";
        public const string SearchResultsView = "~/Pages/PersonSearch/PersonSearchResults.cshtml";
        public const string ResultMessage = "ResultMessage";

        private IHttpCrudService<PersonSearchModel> crudService;
        
        /// <summary>
        /// Called right before action methods executed
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TempData[ResultMessage] = Defaults.String;
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="crud"></param>
        public PersonSearchController(IHttpCrudService<PersonSearchModel> crud)
        {
            crudService = crud;
        }

        /// <summary>
        /// Shows the search page
        /// </summary>
        /// <returns>Initialized search page</returns>
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult Search()
        {            
            return View(PersonSearchController.SearchView, new PersonSearchModel());
        }

        /// <summary>
        /// Performs a full-post back search, accepting search parameters and returning search parameters and results
        /// </summary>
        /// <param name="model">Model of type IPerson with results</param>
        /// <returns>View of search parameters and any found results</returns>
        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> Search(PersonModel data)
        {
            var query = $"{data.Key}/{data.FirstName}/{data.LastName}";
            var searchResults = await crudService.Read(query);
            TempData[ResultMessage] = $"{searchResults.Results.Count} matches found";
            return View(PersonSearchController.SearchView, searchResults);
        }

        /// <summary>
        /// Client-side version of search, refreshing only the results region
        /// </summary>
        /// <param name="id">ID to include in search results</param>
        /// <param name="firstName">Text to search in first name</param>
        /// <param name="lastName">Text to search in the last name field</param>
        /// <returns>Partial view of only the search results region</returns>
        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> SearchResults(string id, string firstName, string lastName)
        {
            var query = $"{id}/{System.Web.HttpUtility.UrlEncode(firstName ?? " ")}/{System.Web.HttpUtility.UrlEncode(lastName ?? " ")}";
            var searchResults = await crudService.Read(query);
            TempData[ResultMessage] = $"{searchResults.Results.Count} matches found";
            return PartialView(PersonSearchController.SearchResultsView, searchResults.Results);
        }
    }
}