//-----------------------------------------------------------------------
// <copyright file="GenderInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Name;
using System;
using System.Collections.Generic;

namespace Genesys.Entity.Person
{
    /// <summary>
    /// EntityGender
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class GenderInfo : ActiveRecordValue<GenderInfo>, IFormattable, INameCode
    {
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
        public GenderInfo()
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
                if (formatProvider.GetFormat(this.GetType()) is ICustomFormatter formatter) { return formatter.Format(format, this, formatProvider); }
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
