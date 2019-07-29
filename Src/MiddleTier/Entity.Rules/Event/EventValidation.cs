//-----------------------------------------------------------------------
// <copyright file="EventValidation.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
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
