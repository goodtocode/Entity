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

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Groups define how an event is processed and defaults (i.e. invite prompts for email template first, then x.)
    /// </summary>
    public struct EventGroups
    {
        /// <summary>
        /// Private event, like a house party
        /// </summary>
        public static Guid GetTogether = new Guid("26833573-F93C-47DC-9812-13A4FF7DDFB6");

        /// <summary>
        /// Public event, where anybody can attend
        /// </summary>
        public static Guid PublicEvent = new Guid("11AD3246-967F-4318-B82B-B8496772DB84");

        /// <summary>
        /// A personal experience, that has happened in the past
        /// </summary>
        public static Guid PersonalExperience = new Guid("784E9CD6-AA75-4023-9220-B40318733339");

        /// <summary>
        /// An organized meeting, typically repeating
        /// </summary>
        public static Guid Meeting = new Guid("5F1092F7-0199-4B5B-A92C-27F623D37FF4");
    }
}