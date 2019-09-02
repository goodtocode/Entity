//-----------------------------------------------------------------------
// <copyright file="PersonController.cs" company="GoodToCode">
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
using GoodToCode.Extras.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Creates a Person
    /// </summary>
    [Authorize]
    public class PersonController : Controller
    {
        public const string ControllerName = "Person";
        public const string SummaryAction = "Summary";
        public const string SummaryView = "~/Views/Person/PersonSummary.cshtml";
        public const string CreateAction = "Create";
        public const string CreateActionText = CreateAction;
        public const string CreateView = "~/Views/Person/PersonCreate.cshtml";
        public const string EditAction = "Edit";
        public const string EditView = "~/Views/Person/PersonEdit.cshtml";
        public const string DeleteAction = "Delete";
        public const string DeleteView = "~/Views/Person/PersonDelete.cshtml";
        public const string ResultMessage = "ResultMessage";

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
        /// Displays entity
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Summary(string id)
        {
            // Change to Web API call to resource server

            //var reader = new EntityReader<PersonInfo>();
            //var Person = (id.IsInteger() ?
            //    reader.GetById(id.TryParseInt32()) :
            //    reader.GetByKey(id.TryParseGuid()));
            //if (Person.IsNew)
            //    TempData[ResultMessage] = "Person not found";

            //return View(PersonController.SummaryView, Person.CastOrFill<PersonModel>());
            return null;
        }

        /// <summary>
        /// Person Summary with Edit/Delete functionality
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Summary(PersonModel model)
        {
            // Change to Web API call to resource server

            //var reader = new EntityReader<PersonInfo>();
            //var Person = reader.GetById(model.Id);
            //return View(PersonController.EditView, Person.CastOrFill<PersonModel>());
            return null;
        }
        /// <summary>
        /// Displays entity for editing
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult Create()
        {
            return View(PersonController.CreateView, new PersonModel());
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model">Full Person model worth of data to be saved</param>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Create(PersonModel model)
        {
            // Change to Web API call to resource server

            //var Person = model.CastOrFill<PersonInfo>();

            //Person = Person.Save();
            //if (!Person.IsNew)
            //    TempData[ResultMessage] = "Successfully created";
            //else
            //    TempData[ResultMessage] = "Failed to create";

            //return View(PersonController.SummaryView, Person.CastOrFill<PersonModel>());
            return null;
        }

        /// <summary>
        /// Displays entity for editing
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult Edit(string id)
        {
            // Change to Web API call to resource server
            // Change Edit to Update

            //var reader = new EntityReader<PersonInfo>();
            //var Person = reader.GetById(id.TryParseInt32());

            //if (Person.IsNew)
            //    TempData[ResultMessage] = "No Person found";

            //return View(PersonController.EditView, Person.CastOrFill<PersonModel>());
            return null;
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model">Full Person model worth of data with user changes</param>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Edit(PersonModel model)
        {
            // Change to Web API call to resource server
            // Change Edit to Update

            //var reader = new EntityReader<PersonInfo>();
            //var Person = model.CastOrFill<PersonInfo>();

            //Person = Person.Save();
            //if (!Person.IsNew)
            //    TempData[ResultMessage] = "Successfully saved";
            //else
            //    TempData[ResultMessage] = "Failed to save";

            //return View(PersonController.SummaryView, Person.CastOrFill<PersonModel>());
            return null;
        }

        /// <summary>
        /// Displays entity for deleting
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult Delete(string id)
        {
            // Change to Web API call to resource server

            //var reader = new EntityReader<PersonInfo>();
            //var Person = reader.GetById(id.TryParseInt32());

            //if (Person.IsNew)
            //    TempData[ResultMessage] = "No Person found";                

            //return View(PersonController.DeleteView, Person.CastOrFill<PersonModel>());
            return null;
        }

        /// <summary>
        /// Deletes a Person
        /// </summary>
        /// <param name="model">Person to delete</param>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Delete(PersonModel model)
        {
            // Change to Web API call to resource server

            //var reader = new EntityReader<PersonInfo>();
            //var Person = reader.GetByKey(model.Key);

            //Person = Person.Delete();
            //if (Person.IsNew)
            //    TempData[ResultMessage] = "Successfully deleted";
            //else
            //    TempData[ResultMessage] = "Failed to delete";

            //return View(PersonSearchController.SearchView, Person.CastOrFill<PersonSearchModel>());
            return null;
        }

        /// <summary>
        /// Can connect to the database?
        /// </summary>
        /// <returns></returns>
        public static bool CanConnect()
        {
            // Change to DI injected configuration

            var returnValue = Defaults.Boolean;
            //var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);
            //using (var connection = new SqlConnection(configuration.ConnectionStringValue("DefaultConnection")))
            //{
            //    returnValue = connection.CanOpen();
            //}
            return returnValue;
        }
    }
}