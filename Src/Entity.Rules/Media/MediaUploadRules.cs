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
