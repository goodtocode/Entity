//-----------------------------------------------------------------------
// <copyright file="PersonSearchManager.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Entity.Flow;
using Genesys.Framework.Session;

namespace Genesys.Entity.Person
{
    /// <summary>
    /// Interop instructions
    /// </summary>
    
    public sealed class PersonSearchManager : FlowInteropManager<IPerson>
    {
        /// <summary>
        /// External Route to this workflow's endpoint for native apps and distributed systems
        /// </summary>
        public override IFlowRoute WebServicesRoute { get; protected set; } = new WorkfloRoute("PersonSearch", "PersonSearch");

        /// <summary>
        /// In-domain Route to this workflow's endpoint for WebServices, MVC apps and any other presentation tier functionality.
        /// </summary>
        public override IFlowRoute MidServicesRoute { get; protected set; } = new WorkfloRoute("PersonSearch", "PersonSearch");

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonSearchManager() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonSearchManager(ISessionContext context, IPerson dataIn) : base(context, dataIn) { }

        /// <summary>
        /// Constructor with hydration
        /// </summary>
        /// <param name="rootUrl">Root Url of the service without trailing slash</param>
        /// <param name="context">User, device and app context</param>
        /// <param name="dataIn">Data to be sent</param>
        public PersonSearchManager(string rootUrl, ISessionContext context, IPerson dataIn) : base(rootUrl, context, dataIn) { }
    }
}
