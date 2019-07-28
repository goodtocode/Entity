//-----------------------------------------------------------------------
// <copyright file="ScheduleModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using Genesys.Framework.Validation;
using System.Collections.Generic;

namespace Genesys.Entity.Schedule
{
    /// <summary>
    /// Schedule
    /// </summary>
    public class ScheduleModel : EntityModel<ScheduleModel>
    {
        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ScheduleModel>> Rules()
            { return new List<IValidationRule<ScheduleModel>>()
            {
                new ValidationRule<ScheduleModel>(x => x.Name.Length > 0, "LocationName is required")
            };
        }

        /// <summary>
        /// Name of Location where the event will be held
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description of Location where the event will be held
        /// </summary>
        public string Description { get; set; } = Defaults.String;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ScheduleModel() : base() { }

        /// <summary>
        /// Returns name
        /// </summary>        
        public override string ToString()
        {
            return Name;
        }
    }
}