
using GoodToCode.Entity.Schedule;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Appointment record
    /// </summary>
    public interface IAppointmentInfo : ISlotLocationKey, ISlotResourceKey, ITimeRangeKey
    {
        /// <summary>
        /// AppointmentName
        /// </summary>
        string AppointmentName { get; set; }

        /// <summary>
        /// LocationDescription
        /// </summary>
        string AppointmentDescription { get; set; }
    }
}
