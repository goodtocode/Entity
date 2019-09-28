
using GoodToCode.Entity.Schedule;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Appointment
{
    /// <summary>
    /// Appointment record
    /// </summary>
    public interface IAppointment : INameDescription, ISlotLocationKey, ISlotResourceKey, ITimeRangeKey
    {
    }
}
