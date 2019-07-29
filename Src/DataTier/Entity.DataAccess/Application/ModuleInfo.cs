//-----------------------------------------------------------------------
// <copyright file="ModuleInfo.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extras.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Name;
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Module DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ModuleInfo : ActiveRecordValue<ModuleInfo>, INameId
    {
        /// <summary>
        /// Name of this item
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Holds Ids of global records
        /// </summary>
        public struct Modules
        {
            /// <summary>
            /// Sandbox record, for general purpose use and testing. Not for Production Use!
            /// </summary>
            public static Guid Framework { get; } = new Guid("FED60864-3604-407E-8379-BEA5823F7CA1");
        }
    }
}
