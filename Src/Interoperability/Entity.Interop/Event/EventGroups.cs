//-----------------------------------------------------------------------
// <copyright file="EventInfo.cs" company="GoodToCode">
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
    /// Groups define how an event is processed and defaults (i.e. invite prompts for email template first, then x.)
    /// </summary>
    public struct EventGroups
    {
        /// <summary>
        /// Private event, like a house party
        /// </summary>
        public static Guid GetTogether = new Guid("26833573-F93C-47DC-9812-13A4FF7DDFB6");

        /// <summary>
        /// Public event, where anybody can attend
        /// </summary>
        public static Guid PublicEvent = new Guid("11AD3246-967F-4318-B82B-B8496772DB84");

        /// <summary>
        /// A personal experience, that has happened in the past
        /// </summary>
        public static Guid PersonalExperience = new Guid("784E9CD6-AA75-4023-9220-B40318733339");

        /// <summary>
        /// An organized meeting, typically repeating
        /// </summary>
        public static Guid Meeting = new Guid("5F1092F7-0199-4B5B-A92C-27F623D37FF4");
    }
}