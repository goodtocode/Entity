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
using GoodToCode.Extensions;
using System;

namespace GoodToCode.Framework.Flow
{
    /// <summary>
    /// Workflow steps
    /// </summary>
    public struct FlowSteps
    {
        /// <summary>
        /// Workflow has not started
        /// </summary>
        public static Guid Unprocessed = Defaults.Guid;

        /// <summary>
        /// Workflow still has steps to finish
        /// </summary>
        public static Guid PendingNextStep = new Guid("E18EE532-2431-40F3-B696-2435FA7720A4");

        /// <summary>
        /// Workflow complete
        /// </summary>
        public static Guid Completed = new Guid("3767F875-7E3D-4F12-B85D-61E31E6D43F1");

        /// <summary>
        /// Workflow previously completed, cant re-run
        /// </summary>
        public static Guid WorkflowAlreadyCompleted = new Guid("05F52306-143E-4A28-A669-5370428BCB32");

        /// <summary>
        /// Failed unexpectedly
        /// </summary>
        public static Guid FailedUnexpected = new Guid("B6D4A2AA-D503-4200-B1C0-009629D7D6B9");

        /// <summary>
        /// Failed processing payment
        /// </summary>
        public static Guid FailedPayment = new Guid("8F952F23-5289-4BBD-82C5-1677A8F38858");

        /// <summary>
        /// Failed due to not authorized to perform task
        /// </summary>
        public static Guid FailedNotAuthorized = new Guid("DCBCA742-564C-40A8-B6C1-1D8211AC7297");

        /// <summary>
        /// Validation failed
        /// </summary>
        public static Guid FailedValidation = new Guid("8EEF8D96-9DBE-449B-9EAE-A2E6D34F7E90");
    }
}
