//-----------------------------------------------------------------------
// <copyright file="Idevice.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Device;
using Genesys.Framework.Name;

namespace Genesys.Entity.Device
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
