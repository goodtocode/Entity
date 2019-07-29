//-----------------------------------------------------------------------
// <copyright file="ITimeRecurring.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// TimeRecurring for an entity (location or resource)
    /// </summary>    
    public interface ITimeRecurring
    {
        /// <summary>
        /// BeginDay
        /// </summary>
        int BeginDay { get; set; }

        /// <summary>
        /// EndDay
        /// </summary>
        int EndDay { get; set; }

        /// <summary>
        /// BeginTime
        /// </summary>
        DateTime BeginTime { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// Interval of recurring. Most are "all intervals". Some may be every nth interval.
        /// </summary>
        int Interval { get; set; }
    }
}
