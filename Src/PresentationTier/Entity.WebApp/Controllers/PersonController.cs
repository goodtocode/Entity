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
using GoodToCode.Extensions;
using GoodToCode.Extras.Configuration;
using GoodToCode.Extras.Net;
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
    public class PersonController : Controller
    {
        public const string ControllerName = "Person";
        public const string SummaryAction = "Summary";
        public const string SummaryView = "~/Pages/Person/PersonSummary.cshtml";
        public const string CreateAction = "Create";
        public const string CreateActionText = CreateAction;
        public const string CreateView = "~/Pages/Person/PersonCreate.cshtml";
        public const string EditAction = "Edit";
        public const string EditView = "~/Pages/Person/PersonEdit.cshtml";
        public const string DeleteAction = "Delete";
        public const string DeleteView = "~/Pages/Person/PersonDelete.cshtml";
        public const string ResultMessage = "ResultMessage";

        private IHttpCrudService<PersonModel> crudService;

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
        public PersonController(IHttpCrudService<PersonModel> crud)
        {
            crudService = crud;
        }

        /// <summary>
        /// Displays entity
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult> Summary(string id)
        {
            var person = await crudService.Read(id.TryParseInt32());
            if (person.IsNew)
                TempData[ResultMessage] = "Person not found";

            return View(PersonController.SummaryView, person);
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
        public async Task<ActionResult> Create(PersonModel model)
        {
            var person = await crudService.Create(model);
            if (!person.IsNew)
                TempData[ResultMessage] = "Successfully created";
            else
                TempData[ResultMessage] = "Failed to create";

            return View(PersonController.SummaryView, person);
        }

        /// <summary>
        /// Displays entity for editing
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet()]
        public async Task<ActionResult> Edit(string id)
        {
            var person = await crudService.Read(id.TryParseInt32());
            if (person.IsNew)
                TempData[ResultMessage] = "Person not found";

            return View(PersonController.EditView, person);
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model">Full Person model worth of data with user changes</param>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> Edit(PersonModel model)
        {
            var person = await crudService.Create(model);
            if (!person.IsNew)
                TempData[ResultMessage] = "Successfully saved";
            else
                TempData[ResultMessage] = "Failed to save";

            return View(PersonController.SummaryView, person);
        }

        /// <summary>
        /// Displays entity for deleting
        /// </summary>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpGet()]
        public async Task<ActionResult> Delete(string id)
        {
            var person = await crudService.Read(id.TryParseInt32());
            if (person.IsNew)
                TempData[ResultMessage] = "Person not found";

            return View(PersonController.DeleteView, person);
        }

        /// <summary>
        /// Deletes a Person
        /// </summary>
        /// <param name="model">Person to delete</param>
        /// <returns>View rendered with model data</returns>
        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> Delete(PersonModel model)
        {
            var person = await crudService.Create(model);
            if (person.IsNew)
                TempData[ResultMessage] = "Successfully deleted";
            else
                TempData[ResultMessage] = "Failed to delete";

            return View(PersonController.SummaryView, person);
        }

        /// <summary>
        /// Can connect to the database?
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> CanConnect()
        {
            var returnValue = Defaults.Boolean;
            var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);

            using (var client = new HttpRequestGetString(configuration.AppSettingValue("MyWebService") + "/HomeApi"))
            {
                await client.SendAsync();
                returnValue = client.Response.IsSuccessStatusCode;
            }
            return returnValue;
        }
    }
}