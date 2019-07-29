//-----------------------------------------------------------------------
// <copyright file="ISlotKey.cs" company="GoodToCode">
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
