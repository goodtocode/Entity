﻿//-----------------------------------------------------------------------
// <copyright file="IDetail.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Framework.Name;
using System;

namespace Genesys.Entity.Detail
{
    /// <summary>
    /// Detail of an event, like parking, tickets, etc.
    /// </summary>    
    public interface IDetail : IDetailTypeKey, INameDescription
    {
        /// <summary>
        /// Detail data, typically text describing the detail type classification
        /// </summary>
        string DetailData { get; }
    }
}
