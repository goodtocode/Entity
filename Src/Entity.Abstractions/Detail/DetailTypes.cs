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

namespace GoodToCode.Entity.Detail
{
    /// <summary>
    /// Types of details
    /// </summary>
    public struct DetailTypes
    {
        /// <summary>
        /// Info about the WebSite
        /// </summary>
        public static Guid WebSite = new Guid("DDC2033A-8977-49CA-85E9-1D780567F522");

        /// <summary>
        /// Info about the HoursOfOperation
        /// </summary>
        public static Guid HoursOfOperation = new Guid("0A9CB93C-79AB-440D-9681-2CB461AFBA66");

        /// <summary>
        /// Info about Admission 
        /// </summary>
        public static Guid Admission = new Guid("A74424D0-D392-4CE6-AB96-3619196AB3EB");

        /// <summary>
        /// Info about HowToEntity 
        /// </summary>
        public static Guid HowToEntity = new Guid("9C00E926-F4A6-402B-87C8-3647B54C7B55");

        /// <summary>
        /// Info about the Directions
        /// </summary>
        public static Guid Directions = new Guid("61363878-37FD-499A-943C-374650E31C3E");

        /// <summary>
        /// Info about MoreInfo 
        /// </summary>
        public static Guid MoreInfo = new Guid("57BC7B92-2D59-4252-B087-9D3AE2D7E172");

        /// <summary>
        /// Info about the Parking
        /// </summary>
        public static Guid Parking = new Guid("130AEFFE-0162-4BD3-B8E1-FA6E82FF3377");
    }
}
