//-----------------------------------------------------------------------
// <copyright file="ITimeRange.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// TimeRange for a schedule. Schedule = Resource + TimeRange + Location
    /// </summary>    
    public interface ITimeRange
    {
        /// <summary>
        /// BeginDate
        /// </summary>
        DateTime BeginDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime EndDate { get; set; }
    }
}
