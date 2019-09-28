
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A slot in a schedule + Resource
    /// </summary>
    public interface ISlotResourceKey
    {
        /// <summary>
        /// Key of the Slot + Resource combination
        /// </summary>
        Guid SlotResourceKey { get; set; }
    }
}
