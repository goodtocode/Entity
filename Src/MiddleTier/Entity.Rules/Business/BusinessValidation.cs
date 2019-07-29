//-----------------------------------------------------------------------
// <copyright file="BusinessValidation.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// Upload rules and authorizations
    /// </summary>
    public class BusinessValidation
    {
        /// <summary>
        /// Checks if business info is complete
        /// </summary>
        public bool IsComplete()
        {
            var returnValue = Defaults.Boolean;

            //if ((Name != Defaults.String))
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }

        /// <summary>
        /// DoesBusinessExists
        /// </summary>
        /// <param name="entityId">Business to check</param>
        public bool DoesExists(int entityId)
        {
            var returnValue = Defaults.Boolean;

            //if (BusinessInfo.GetById(entityId).Id != Defaults.Integer)
            //{
            //    returnValue = true;
            //}

            return returnValue;
        }
    }
}
