//-----------------------------------------------------------------------
// <copyright file="GenderInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Genesys.Entity.Person
{
    /// <summary>
    /// ISO 5218 Standard for Gender values
    /// </summary>
    public struct Genders
    {
        /// <summary>
        /// Default. Not set
        /// </summary>
        public static KeyValuePair<int, string> NotSet { get; } = new KeyValuePair<int, string>(-1, "Not Set");

        /// <summary>
        /// Unknown gender
        /// </summary>
        public static KeyValuePair<int, string> NotKnown { get; } = new KeyValuePair<int, string>(0, "Not Known");

        /// <summary>
        /// Male gender
        /// </summary>
        public static KeyValuePair<int, string> Male { get; } = new KeyValuePair<int, string>(1, "Male");

        /// <summary>
        /// Femal Gender
        /// </summary>
        public static KeyValuePair<int, string> Female { get; } = new KeyValuePair<int, string>(2, "Female");

        /// <summary>
        /// Not applicable or do not want to specify
        /// </summary>
        public static KeyValuePair<int, string> NotApplicable { get; } = new KeyValuePair<int, string>(9, "Not Applicable");
    }
}
