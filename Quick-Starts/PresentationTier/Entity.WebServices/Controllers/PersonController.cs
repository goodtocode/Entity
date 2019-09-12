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
using GoodToCode.Extensions.Configuration;
using GoodToCode.Framework.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace GoodToCode.Entity.WebServices
{
    /// <summary>
    /// Accepts HttpGet, HttpPut, HttpPost and HttpDelete operations on a Person
    /// </summary>
    [Produces("application/json")]
    public class PersonController : Controller
    {
        public const string ControllerName = "Person";
        public const string ControllerRoute = "v4/Person";
        public const string GetActionText = "Get Person";
        public const string GetAction = "Get";
        public const string PutAction = "Put";
        public const string PostAction = "Post";
        public const string DeleteAction = "Delete";
        public const int MaxRecords = 500;

        /// <summary>
        /// Retrieves Person by Id
        /// </summary>
        /// <returns>Person that matches the Id, or initialized PersonDto for not found condition</returns>
        [HttpGet(ControllerRoute + "/{key}")]
        public IPerson Get(string key)
        {
            var Person = new PersonInfo();
            using (var reader = new EntityReader<PersonInfo>())
            {
                if (key.IsInteger())
                    Person = reader.GetById(key.TryParseInt32());
                else
                    Person = reader.GetByKey(key.TryParseGuid());
            }

            return Person;
        }

        /// <summary>
        /// Creates a new Person
        /// </summary>
        /// <returns></returns>
        [HttpPut(ControllerRoute)]
        public IPerson Put([FromBody]PersonDto model)
        {
            var Person = model.CastOrFill<PersonInfo>();
            Person = Person.Save();
            return Person;
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model">Full Person model worth of data with user changes</param>
        /// <returns>PersonDto containing Person data</returns>
        [HttpPost(ControllerRoute)]
        public IPerson Post([FromBody]PersonDto model)
        {
            var Person = model.CastOrFill<PersonInfo>();
            Person = Person.Save();
            return Person;
        }

        /// <summary>
        /// Saves changes to a Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete(ControllerRoute + "/{key}")]
        public IPerson Delete(string key)
        {
            var Person = new PersonInfo();
            using (var reader = new EntityReader<PersonInfo>())
            {
                if (key.IsInteger())
                    Person = reader.GetById(key.TryParseInt32());
                else
                    Person = reader.GetByKey(key.TryParseGuid());
            }
            Person = Person.Delete();

            return Person;
        }

        /// <summary>
        /// Can connect to the database?
        /// </summary>
        /// <returns></returns>
        public static bool CanConnect()
        {
            var returnValue = Defaults.Boolean;
            var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);
            using (var connection = new SqlConnection(configuration.ConnectionStringValue("DefaultConnection")))
            {
                returnValue = connection.CanOpen();
            }
            return returnValue;
        }
    }
}