//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Extensions;

namespace GoodToCode.Framework.Flow
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
