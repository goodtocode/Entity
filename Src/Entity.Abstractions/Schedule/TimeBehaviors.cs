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
using System.Collections.Generic;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// Time behavior. -1 is subtract. 0 is no effect. 1 is add.
    /// </summary>
    public struct TimeBehaviors
    {
        /// <summary>
        /// Time adds, or is available, or is in use
        /// </summary>
        public static KeyValuePair<int, string> AddTime { get; } = new KeyValuePair<int, string>(1, "AddTime");

        /// <summary>
        /// Time has no effect on other times
        /// </summary>
        public static KeyValuePair<int, string> DoesNotAffect { get; } = new KeyValuePair<int, string>(-1, "NeutralTime");

        /// <summary>
        /// Time subtracts, or is unavailable, or has been removed
        /// </summary>
        public static KeyValuePair<int, string> SubtractTime { get; } = new KeyValuePair<int, string>(-1, "SubtractTime");        
    }
}
