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
    public class EventPermissions
    {
        /// <summary>
        /// Checks database to see if a RequestingEntityId can view this event
        /// </summary>
        /// <param name="requestingEntityKey">ContacId requesting to view</param>
        /// <param name="EventKey">Event to view</param>        
        public bool CanView(Guid requestingEntityKey, Guid EventKey)
        {
            //var reader = new EntityReader<EventInfo>();
            var returnValue = Defaults.Boolean;
            //var currEvent = reader.GetByKey(EventKey);

            ////* Check For:
            ////*   1. This is a 'public event'
            ////*   2. This person is a friend/trusted
            ////*   3. This person has been sent an invite
            ////*   4. This person is a the creator
            ////*   5. The person has been added to RSVP list by a side action (sent an invite/share link, given a event card)
            //if (CurrEvent.IsCreator(RequestingEntityId) || CurrEvent.PrivacyViewId == RoleGroup.Groups.All)
            //{
            //    returnValue = true;
            //}
            //else if (CurrEvent.PrivacyViewId == RoleGroup.Groups.Registered && UserProfile.GetByEntity(RequestingEntityId).Id != Defaults.Integer)
            //{
            //    returnValue = true;
            //}
            //else if (CurrEvent.PrivacyViewId == RoleGroup.Groups.Friends
            //    && (GuestListEntity.GetByEntity(EventInfo.GetById(EventKey).CreatorId).Where(x => x.EmailAddress == EmailInfo.GetByEntity(RequestingEntityId, EmailInfo.Types.UserName).EmailAddress).Any() == true || EventInfo.HasBeenInvited(RequestingEntityId, EventKey) == true))
            //{
            //    returnValue = true;
            //}
            //else if (CurrEvent.PrivacyViewId == RoleGroup.Groups.Invited && EventInfo.HasBeenInvited(RequestingEntityId, EventKey))
            //{
            //    returnValue = true;
            //}
            //else if (EventRSVP.GetByEntityEvent(RequestingEntityId, EventKey).Id != Defaults.Integer)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// Checks to see if an anonymous view can happen by username
        /// </summary>
        /// <param name="username">Requesting viewer</param>
        /// <param name="userNameEncrypted">Encrypted username value from outside the system</param>
        /// <param name="EventKey">Evnet to view</param>        
        public static bool CanView(string username, string userNameEncrypted, Guid EventKey)
        {
            //var reader = new EntityReader<EventInfo>();
            var returnValue = Defaults.Boolean;
            //var currEvent = reader.GetByKey(EventKey);

            ////* Check For:
            ////*   1. The username must match encrypted string
            ////*   2. The event must not be private
            ////*   3. The username must have been sent an invite
            //if (EncryptionHelper.Encrypt(UserName) == UserNameEncrypted && EventRSVP.GetByEventEmail(EventId, UserName).Id != Defaults.Integer && CurrEvent.PrivacyViewId == RoleGroup.Groups.Creator)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// Can upload a photo for this event
        /// </summary>
        /// <param name="entityId">EntityId</param>
        /// /// <param name="eventId">EventId</param>
        public static bool CanUpload(int eventId, int entityId)
        {
            var returnValue = Defaults.Boolean;

            //// Check For:
            ////   1. This person is a the creator
            ////   2. Photo upload setting
            //if (EventInfo.IsCreator(entityId, eventId) == true)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }
    }
}
