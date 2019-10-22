
using GoodToCode.Framework.Data;
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
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