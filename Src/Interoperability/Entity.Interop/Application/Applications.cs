//-----------------------------------------------------------------------
// <copyright file="ApplicationInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using System;

namespace Genesys.Entity.Application
{
    /// <summary>
    /// Holds Ids of global records
    /// </summary>
    public struct Applications
    {
        /// <summary>
        /// Sandbox record, for general purpose use and testing. Not for Production Use!
        /// </summary>
        public static Guid Sandbox { get; } = new Guid("1EE3F6EC-59A7-4FD3-91D7-22AE3E20D412");
    }
}
