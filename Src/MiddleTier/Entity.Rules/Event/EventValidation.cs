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
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Upload rules and authorizations
    /// </summary>
    public class EventValidation
    {
        /// <summary>
        /// Checks data to see if minimum complete
        /// </summary>
        public bool IsComplete()
        {
            var returnValue = Defaults.Boolean;

            //if (Name != Defaults.String & Description != Defaults.String & Code != Defaults.String & BeginDate != Defaults.Date & EndDate != Defaults.Date)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// Checks database to see if this is a Editor
        /// </summary>
        /// <param name="entityId">EntityId</param>        
        public bool IsCreator(int entityId)
        {
            var returnValue = Defaults.Boolean;

            //if (CreatorKey == entityId)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }
        
        /// <summary>
        /// Checks DB for this event
        /// </summary>
        /// <param name="eventId">Id of the event to check</param>
        public static bool DoesExist(int eventId)
        {
            var returnValue = Defaults.Boolean;

            //if (EventInfo.GetById(eventId).Id != Defaults.Integer)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// Has been invited to event
        /// </summary>
        /// <param name="entityId">EntityId</param>
        /// <param name="eventId">EventId</param>
        public static bool HasBeenInvited(int entityId, int eventId)
        {
            return false;
        }
    }
}
