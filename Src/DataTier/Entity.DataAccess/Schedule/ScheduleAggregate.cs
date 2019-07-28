//-----------------------------------------------------------------------
// <copyright file="ScheduleAggregate.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extras.Data;
using System.Collections.Generic;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ScheduleAggregate : ScheduleInfo
    {       
        public IList<SlotAggregate> Slots { get; internal set;  }



        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleAggregate() : base() { }

        /// <summary>
        /// Commits to database
        /// </summary>
        public new ScheduleAggregate Save()
        {
            return this;
        }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}