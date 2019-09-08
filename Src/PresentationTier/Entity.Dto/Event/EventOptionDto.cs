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
using System.Linq;
using GoodToCode.Entity.Option;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// For one selection in a OptionGroup's properties
    /// </summary>
    public class EventOptionDto : EntityDto<EventOptionDto>, IEventOption
    {
        private readonly OptionGroupDto _group = new OptionGroupDto();
        private readonly IQueryable<OptionDto> _selections;

        /// <summary>
        /// EntityId regarding this Option
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Possible selections
        /// </summary>
        public IQueryable<OptionDto> Selections
        {
            get { return _selections; }
        }
        
        /// <summary>
        /// Group
        /// </summary>
        public OptionGroupDto Group
        {
            get { return _group; }
        }

        /// <summary>
        /// Option whose value is being selected
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Selected value
        /// </summary>
        public string Value
        {
            get { return Selections.Where(x => x.Key == this.OptionKey).FirstOrDefault().Name; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventOptionDto()
            : base()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventOptionDto(IQueryable<OptionDto> selections)
            : base()
        {
            _selections = selections;
        }    }   
}