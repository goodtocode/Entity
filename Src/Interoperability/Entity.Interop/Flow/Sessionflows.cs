//-----------------------------------------------------------------------
// <copyright file="SessionflowModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Name;

namespace Genesys.Entity.Flow
{
    /// <summary>
    /// Holds Ids of global records
    /// </summary>
    public struct Sessionflows
    {
        /// <summary>
        /// Sandbox record, for general purpose use and testing. Not for Production Use!
        /// </summary>
        public static Guid General { get; } = new Guid("6DA2EC13-99C9-41AA-BBBF-612136A47223");
    }
}