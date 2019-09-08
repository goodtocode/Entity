//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
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
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Upload rules and authorizations
    /// </summary>
    public class PersonValidation
    {
        /// <summary>
        /// Checks database to see if a EntityId can view
        /// </summary>
        /// <param name="viewer">ViewerEntityId</param>
        /// <param name="person">PersonEntityId</param>
        public static bool CanView(IEntity viewer, IPerson person)
        {
            var returnValue = Defaults.Boolean;
            string privacySetting = Defaults.String;

            //if (viewer.Key == person.Key)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// Checks if personal info is complete
        /// </summary>
        public bool IsComplete(IPerson person)
        {
            var returnValue = Defaults.Boolean;
            //var rules = new List<ValidationRule<PersonInfo>>()
            //{
            //    new ValidationRule<PersonInfo>("FirstName", x => x.FirstName.Length > 0),
            //    new ValidationRule<PersonInfo>("LastName", x => x.LastName.Length > 0)
            //};

            //this.Vali

            //// Check for enough data
            //if ((this.FirstName != Defaults.String) & (this.LastName != Defaults.String))
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// DoesPersonExists
        /// </summary>
        /// <param name="entityId">Person to check</param>
        public static bool DoesExists(int entityId)
        {
            var returnValue = Defaults.Boolean;

            //if (PersonInfo.GetById(entityId).Id != Defaults.Integer)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }
    }
}
