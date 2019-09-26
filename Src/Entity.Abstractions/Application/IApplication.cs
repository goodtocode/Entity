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
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Global class containing global information for an application
    /// Often a singleton/static object, one per application project
    /// </summary>    
    public interface IApplication : INameKey
    {
        /// <summary>
        /// Id of the business owning the application
        /// </summary>
        Guid BusinessKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PrivacyUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string TermsUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime TermsRevisedDate { get; set; }
    }
}