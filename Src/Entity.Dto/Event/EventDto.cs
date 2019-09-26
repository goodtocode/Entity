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
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Flat and thin event model used for view only pages
    /// </summary>
    /// <remarks></remarks>
    public class EventDto : EntityDto<EventDto>, IEvent
    {
        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// EventGroupId
        /// </summary>
        public Guid EventGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// EventTypeId
        /// </summary>
        public Guid EventTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// CreatorId
        /// </summary>
        public Guid EventCreatorKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public EventDto() : base() { }
    }
}
