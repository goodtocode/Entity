
using System;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Appointment record
    /// </summary>
    public interface IAppointmentKey
    {
        /// <summary>
        /// AppointmentKey
        /// </summary>
        Guid AppointmentKey { get; set; }
    }
}
