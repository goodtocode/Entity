
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A slot in a schedule + location
    /// </summary>
    public interface ISlotLocationKey
    {
        /// <summary>
        /// Key of the Slot + Location combination
        /// </summary>
        Guid SlotLocationKey { get; set; }
    }
}
