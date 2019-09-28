
using System;
using GoodToCode.Framework.Device;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Device
{
    /// <summary>
    /// Device
    /// </summary>    
    
    public interface IDevice : IName, IDeviceUuid, IApplicationUuid
    {
        /// <summary>
        /// Model
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// Manufacturer
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// OSName
        /// </summary>
        string OSName { get; set; }
    }
}
