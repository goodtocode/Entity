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
using GoodToCode.Framework.Name;
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// EntityGender
    /// </summary>    
    public class GenderDto : EntityDto<GenderDto>, IFormattable, INameCode
    {
        /// <summary>
        /// List of Genders, bindable to int Id and string Name
        /// </summary>
        public List<KeyValuePair<int, string>> GenderSelections()
        {
            return new List<KeyValuePair<int, string>>() { Person.Genders.NotSet, Person.Genders.Male, Person.Genders.Female };
        }

        /// <summary>
        /// Friendly name of the Gender
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Gender code: M, F, N, U, A
        /// </summary>
        public string Code { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public GenderDto()
            : base()
        {
        }

        /// <summary>
        /// Concatenates name field into common combinations (G, cn)
        /// </summary>
        /// <param name="format">G (Name), cn (Code - Name)</param>
        /// <param name="formatProvider">ICustomFormatter compatible class</param>
        /// <returns>Name field formatted in common combinations</returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                if (formatProvider.GetFormat(GetType()) is ICustomFormatter formatter) { return formatter.Format(format, this, formatProvider); }
            }
            switch (format)
            {
                case "cn": return $"{Code} - {Name}";
                case "G":
                default: return this.Name;
            }
        }
    }
}
