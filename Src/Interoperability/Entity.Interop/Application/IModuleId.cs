//-----------------------------------------------------------------------
// <copyright file="IModuleId.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Module Id
    /// </summary>    
    
    public interface IModuleId
    {
        /// <summary>
        /// ModuleId
        /// </summary>
        int ModuleId { get; set; }
    }
}
