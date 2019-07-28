//-----------------------------------------------------------------------
// <copyright file="FlowModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using Genesys.Framework.Name;

namespace Genesys.Entity.Flow
{
    /// <summary>
    /// Contains workflows and their steps
    /// </summary>
    public class FlowModel : ValueModel<FlowModel>, INameDescription
	{
        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Friendly description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Time in seconds, when this flow will timeout and require a new activity record to begin
        /// </summary>
        public int TimeoutInSeconds { get; set; } = Defaults.Integer;
    }
}
