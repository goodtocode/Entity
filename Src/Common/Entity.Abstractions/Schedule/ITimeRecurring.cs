﻿//-----------------------------------------------------------------------
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

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// TimeRecurring for an entity (location or resource)
    /// </summary>    
    public interface ITimeRecurring
    {
        /// <summary>
        /// BeginDay
        /// </summary>
        int BeginDay { get; set; }

        /// <summary>
        /// EndDay
        /// </summary>
        int EndDay { get; set; }

        /// <summary>
        /// BeginTime
        /// </summary>
        DateTime BeginTime { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// Interval of recurring. Most are "all intervals". Some may be every nth interval.
        /// </summary>
        int Interval { get; set; }
    }
}
