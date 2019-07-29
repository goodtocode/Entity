//-----------------------------------------------------------------------
// <copyright file="IFlowInteropManager.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Framework.Worker;
using System;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Interop for routes, data in and result of a Flow
    /// </summary> 
    public interface IFlowInteropManager<TDataIn>
    {
        /// <summary>
        /// Root Url to services that accept these requests
        /// </summary>
        string RootUrl { get; set;  }

        /// <summary>
        /// Route to out-of-domain DMZ (external) app services
        /// </summary>
        IFlowRoute WebServicesRoute { get; }

        /// <summary>
        /// Route to in-domain mid services
        /// </summary>
        IFlowRoute MidServicesRoute { get; }

        /// <summary>
        /// Parameter in, encapsulates Context and DataIn
        /// </summary>
        IWorkerParameter<TDataIn> Parameter { get; set; }
    }
}
