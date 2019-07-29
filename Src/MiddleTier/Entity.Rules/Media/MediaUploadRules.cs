//-----------------------------------------------------------------------
// <copyright file="UploadRules.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
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
