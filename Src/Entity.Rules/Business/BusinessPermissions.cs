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
