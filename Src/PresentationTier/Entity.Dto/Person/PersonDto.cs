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
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Common object across models and business entity
    /// </summary>
    /// <remarks></remarks>
    
    public class PersonDto : EntityDto<PersonDto>, IPerson, IFormattable
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; } = Defaults.String;

        /// <summary>
        /// MiddleName
        /// </summary>
        public string MiddleName { get; set; } = Defaults.String;

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; } = Defaults.String;

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; } = Defaults.Date;

        /// <summary>
        /// Gender Id (ISO/IEC 5218)
        /// </summary>
        public int GenderId { get; set; } = Defaults.Int32;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public PersonDto()
            : base()
        {
        }

        /// <summary>
        /// supports fml (First Middle Last), lfm (Last, First Middle)
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                ICustomFormatter fmt = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
                if (fmt != null) { return fmt.Format(format, this, formatProvider); }
            }
            switch (format)
            {
                case "lfm": return String.Format("{0}, {1} {2}", this.LastName, this.FirstName, this.MiddleName);
                case "lfMI": return String.Format("{0}, {1} {2}.", this.LastName, this.FirstName, this.MiddleName.SubstringSafe(0,1));
                case "fMIl": return String.Format("{0} {1}. {2}", this.FirstName, this.MiddleName.SubstringSafe(0, 1), this.LastName);
                case "fl": return String.Format("{0} {1}", this.FirstName, this.LastName);
                case "fml":
                case "G":
                default: return String.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName); 
            }
        }
    }
}
