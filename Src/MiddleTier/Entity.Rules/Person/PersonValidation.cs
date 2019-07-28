//-----------------------------------------------------------------------
//-----------------------------------------------------------------------
// <copyright file="UploadRules.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Person
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
