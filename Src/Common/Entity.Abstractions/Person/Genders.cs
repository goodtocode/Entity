//-----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="GoodToCode">
//      Copyright (c) 2017-2018 GoodToCode. All rights reserved.
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
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// ISO 5218 Standard for Gender values
    /// </summary>
    public struct Genders
    {
        /// <summary>
        /// Default. Not set
        /// </summary>
        public static Tuple<int, string, string> NotSet { get; } = new Tuple<int, string, string>(-1, "", "Not Set");

        /// <summary>
        /// Unknown gender
        /// </summary>
        public static Tuple<int, string, string> NotKnown { get; } = new Tuple<int, string, string>(0, "U", "Not Known");

        /// <summary>
        /// Male gender
        /// </summary>
        public static Tuple<int, string, string> Male { get; } = new Tuple<int, string, string>(1, "M", "Male");

        /// <summary>
        /// Femal Gender
        /// </summary>
        public static Tuple<int, string, string> Female { get; } = new Tuple<int, string, string>(2, "F", "Female");

        /// <summary>
        /// Not applicable or do not want to specify
        /// </summary>
        public static Tuple<int, string, string> NotApplicable { get; } = new Tuple<int, string, string>(9, "N", "Not Applicable");
    }
}
