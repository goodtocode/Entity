//-----------------------------------------------------------------------
// <copyright file="DetailType.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity.Detail
{
    /// <summary>
    /// Types of details
    /// </summary>
    public struct DetailTypes
    {
        /// <summary>
        /// Info about the WebSite
        /// </summary>
        public static Guid WebSite = new Guid("DDC2033A-8977-49CA-85E9-1D780567F522");

        /// <summary>
        /// Info about the HoursOfOperation
        /// </summary>
        public static Guid HoursOfOperation = new Guid("0A9CB93C-79AB-440D-9681-2CB461AFBA66");

        /// <summary>
        /// Info about Admission 
        /// </summary>
        public static Guid Admission = new Guid("A74424D0-D392-4CE6-AB96-3619196AB3EB");

        /// <summary>
        /// Info about HowToEntity 
        /// </summary>
        public static Guid HowToEntity = new Guid("9C00E926-F4A6-402B-87C8-3647B54C7B55");

        /// <summary>
        /// Info about the Directions
        /// </summary>
        public static Guid Directions = new Guid("61363878-37FD-499A-943C-374650E31C3E");

        /// <summary>
        /// Info about MoreInfo 
        /// </summary>
        public static Guid MoreInfo = new Guid("57BC7B92-2D59-4252-B087-9D3AE2D7E172");

        /// <summary>
        /// Info about the Parking
        /// </summary>
        public static Guid Parking = new Guid("130AEFFE-0162-4BD3-B8E1-FA6E82FF3377");
    }
}
