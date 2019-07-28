﻿//-----------------------------------------------------------------------
// <copyright file="IGenderCode.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace Genesys.Entity.Person
{
    /// <summary>
    /// Gender Code
    /// </summary>        
    public interface IGenderCode
    {
        /// <summary>
        /// Gender Id (ISO/IEC 5218)
        /// </summary>
        int GenderCode { get; set; }
    }
}
