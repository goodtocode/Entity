
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A Slot. Slot = Resource + TimeRange + Location
    /// </summary>
    
    public interface ISlotKey
    {
        /// <summary>
        /// Key of a Slot
        /// </summary>
        Guid SlotKey { get; set; }
    }
}
