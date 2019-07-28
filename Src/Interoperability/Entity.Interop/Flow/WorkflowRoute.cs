﻿//-----------------------------------------------------------------------
// <copyright file="MidServicesController.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;

namespace Genesys.Entity.Flow
{
    /// <summary>
    /// Contains all data required to chain workflow service routing from the app, to app services to mid services (and the workflow)
    /// </summary>
    
    public class WorkfloRoute : IFlowRoute
    {
        private string rootUrl = Defaults.String;

        /// <summary>
        /// Root url of route, without trailing slash
        /// </summary>
        public string RootUrl { get { return rootUrl.RemoveLast("/"); } set { rootUrl = value.RemoveLast("/"); } }

        /// <summary>
        /// Unique name of route, for route table
        /// </summary>
        public virtual string Name { get { return ControllerName; } }

        /// <summary>
        /// Actual name of the controller name
        /// </summary>
        public string ControllerName { get; protected set; } // Actual controller name, used for traditional routing

        /// <summary>
        /// Route path containing all fragments except root url
        /// </summary>
        public string Path { get; set; } // Path fragment alias, so can route directly to the controller+action
        
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkfloRoute() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkfloRoute(string controllerName, string path) : base() { ControllerName = controllerName; this.Path = path; }
        
        /// <summary>
        /// Formats string in full Uri path format
        /// </summary>
        
        public override string ToString()
        {
            return String.Format("{0}/{1}", this.RootUrl, this.ControllerName).RemoveLast("/");
        }
    }
}
