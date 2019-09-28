

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface ISlotInfo : ITimeTypeKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string SlotName { get; set; }

        /// <summary>
        /// SlotDescription
        /// </summary>
        string SlotDescription { get; set; }
    }
}
