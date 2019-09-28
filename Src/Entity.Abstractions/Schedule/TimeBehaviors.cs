
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
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
