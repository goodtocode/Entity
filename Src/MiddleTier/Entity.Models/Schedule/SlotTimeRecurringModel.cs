//-----------------------------------------------------------------------
// <copyright file="SlotTimeRecurringModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Events
    /// </summary>
    public class SlotTimeRecurringModel : EntityModel<SlotTimeRecurringModel>, ISlotTimeRecurring
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<SlotTimeRecurringModel>> Rules()
            { return new List<IValidationRule<SlotTimeRecurringModel>>()
            {
                new ValidationRule<SlotTimeRecurringModel>(x => x.SlotName.Length > 0, "LocationName is required"),
                new ValidationRule<SlotTimeRecurringModel>(x => x.BeginDay != Defaults.Integer, "BeginDay is required")
            };
        }

        /// <summary>
        /// Key of the slot record that owns the times
        /// </summary>
        public Guid SlotKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string SlotName { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string SlotDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Beginning day of any 'term'
        /// </summary>
        public int BeginDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Ending day of any 'term'
        /// </summary>
        public int EndDay { get; set; } = Defaults.Integer;

        /// <summary>
        /// Begin time
        /// </summary>
        public DateTime BeginTime { get; set; } = Defaults.Date;

        /// <summary>
        /// End time
        /// </summary>
        public DateTime EndTime { get; set; } = Defaults.Date;

        /// <summary>
        /// Iterval of the recurrance
        /// </summary>
        public int Interval { get; set; } = Defaults.Integer;

        /// <summary>
        /// Type of time being employed (Available, unavailable)
        /// </summary>
        public Guid TimeTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
        /// </summary>
        public int TimeBehavior { get; set; } = TimeBehaviors.AddTime.Key;

        /// <summary>
        /// Constructor
        /// </summary>
        public SlotTimeRecurringModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return SlotName;
        }
    }
}