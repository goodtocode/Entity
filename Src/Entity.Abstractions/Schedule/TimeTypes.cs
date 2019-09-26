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

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Time type that provides a friendly name to a TimeBehavior.
    ///   I.e. TimeTypeName = Available, TimeBehaviorName = Add
    ///   I.e. TimeTypeName = Holiday, TimeBehaviorName = Subtract
    /// </summary>
    public partial struct TimeTypes
    {
        /// <summary>
        /// Time adds, or is available, or is in use
        /// </summary>
        public static Tuple<Guid, string, int> Available { get; } = new Tuple<Guid, string, int>(new Guid("00000000-0000-0000-0000-000000000000"), "Availble", 1);

        /// <summary>
        /// Time has no effect on other times
        /// </summary>
        public static Tuple<Guid, string, int> Unavailable { get; } = new Tuple<Guid, string, int>(new Guid("DAF555C1-ACD9-42AE-870D-8907B3A6D8DB"), "Unavailable", -1);

        /// <summary>
        /// Time subtracts, or is unavailable, or has been removed
        /// </summary>
        public static Tuple<Guid, string, int> Holiday { get; } = new Tuple<Guid, string, int>(new Guid("A832400B-3F9C-4AD4-AF29-5BE50079201C"), "Holiday", -1);        
    }
}
