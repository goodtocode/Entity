//-----------------------------------------------------------------------
// <copyright file="TimeTypes.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Time type that provides a friendly name to a TimeBehavior.
    ///   I.e. TimeTypeName = Available, TimeBehaviorName = Add
    ///   I.e. TimeTypeName = Holiday, TimeBehaviorName = Subtract
    /// </summary>
    public partial struct TimeTypes
    {
        /// <summary>
        /// Time adds, or is available, or is in use
        /// </summary>
        public static Tuple<Guid, string, int> Available { get; } = new Tuple<Guid, string, int>(new Guid("00000000-0000-0000-0000-000000000000"), "Availble", 1);

        /// <summary>
        /// Time has no effect on other times
        /// </summary>
        public static Tuple<Guid, string, int> Unavailable { get; } = new Tuple<Guid, string, int>(new Guid("DAF555C1-ACD9-42AE-870D-8907B3A6D8DB"), "Unavailable", -1);

        /// <summary>
        /// Time subtracts, or is unavailable, or has been removed
        /// </summary>
        public static Tuple<Guid, string, int> Holiday { get; } = new Tuple<Guid, string, int>(new Guid("A832400B-3F9C-4AD4-AF29-5BE50079201C"), "Holiday", -1);        
    }
}
