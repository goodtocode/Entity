//-----------------------------------------------------------------------
// <copyright file="TimeBehaviors.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
    /// </summary>
    public struct TimeBehaviors
    {
        /// <summary>
        /// Time adds, or is available, or is in use
        /// </summary>
        public static KeyValuePair<int, string> AddTime { get; } = new KeyValuePair<int, string>(1, "AddTime");

        /// <summary>
        /// Time has no effect on other times
        /// </summary>
        public static KeyValuePair<int, string> DoesNotAffect { get; } = new KeyValuePair<int, string>(-1, "NeutralTime");

        /// <summary>
        /// Time subtracts, or is unavailable, or has been removed
        /// </summary>
        public static KeyValuePair<int, string> SubtractTime { get; } = new KeyValuePair<int, string>(-1, "SubtractTime");        
    }
}
