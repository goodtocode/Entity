
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// ISO 5218 Standard for Gender values
    /// </summary>
    public struct Genders
    {
        /// <summary>
        /// Default. Not set
        /// </summary>
        public static Tuple<int, string, string> NotSet { get; } = new Tuple<int, string, string>(-1, "", "Not Set");

        /// <summary>
        /// Unknown gender
        /// </summary>
        public static Tuple<int, string, string> NotKnown { get; } = new Tuple<int, string, string>(0, "U", "Not Known");

        /// <summary>
        /// Male gender
        /// </summary>
        public static Tuple<int, string, string> Male { get; } = new Tuple<int, string, string>(1, "M", "Male");

        /// <summary>
        /// Femal Gender
        /// </summary>
        public static Tuple<int, string, string> Female { get; } = new Tuple<int, string, string>(2, "F", "Female");

        /// <summary>
        /// Not applicable or do not want to specify
        /// </summary>
        public static Tuple<int, string, string> NotApplicable { get; } = new Tuple<int, string, string>(9, "N", "Not Applicable");
    }
}
