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
using GoodToCode.Entity.Business;
using GoodToCode.Extensions;
using System;

namespace GoodToCode.Entity.Media
{
    /// <summary>
    /// Upload rules and authorizations
    /// </summary>
    public class BusinessPermissions
    {
        /// <summary>
        /// Checks database to see if a EntityId can view
        /// </summary>
        /// <param name="viewerEntityId">ViewerEntityId</param>
        /// <param name="businessEntityId">BusinessEntityId</param>

        public static bool CanView(int viewerEntityId, int businessEntityId)
        {
            var returnValue = Defaults.Boolean;

            returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// Can upload a photo for this Business
        /// </summary>
        /// <param name="requestingEntityId">Entity making the request</param>

        public bool CanUpload(int requestingEntityId)
        {
            var returnValue = Defaults.Boolean;

            //// Check For:
            ////   1. This Business is a the same
            ////   2. Photo upload setting
            //if (Id == requestingEntityId)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }
    }
}
