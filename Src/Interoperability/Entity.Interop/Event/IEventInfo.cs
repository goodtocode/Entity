//-----------------------------------------------------------------------
// <copyright file="IEventInfo.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Interface to share Business Objects, View Model data across tiers/platforms, without needing a mapper
    /// </summary>    
    public interface IEventInfo : IEventKey
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// EventDescription
        /// </summary>
        string EventDescription { get; set; }
    }
}
