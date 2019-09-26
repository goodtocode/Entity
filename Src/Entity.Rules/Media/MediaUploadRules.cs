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
using System;

namespace GoodToCode.Entity.Media
{
    /// <summary>
    /// Upload rules and authorizations
    /// </summary>
    public class MediaUploadRules
    {
        /// <summary>
        /// Can upload a photo for this person
        /// </summary>
        /// <param name="entity">Entity to add photo to</param>
        /// <param name="requestingEntityKey">Entity making the request</param>
        public bool CanEntityUploadPhoto(IEntity entity, Guid requestingEntityKey)
        {
            return CanEntityUploadPhoto(entity.Key, requestingEntityKey);
        }

        /// <summary>
        /// Can upload a photo for this person
        /// </summary>
        /// <param name="entityKey">Entity making the request</param>
        /// <param name="requestingEntityKey">Entity making the request</param>
        public bool CanEntityUploadPhoto(Guid entityKey, Guid requestingEntityKey)
        {
            var returnValue = Defaults.Boolean;

            // Check For:
            //   1. This person is a the same
            //   2. Photo upload setting
            if (entityKey == requestingEntityKey)
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}
