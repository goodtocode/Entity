//-----------------------------------------------------------------------
// <copyright file="BusinessModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Business
{
    /// <summary>
    /// Common object across models and business entity
    /// </summary>
    /// <remarks></remarks>
    
    public class BusinessDto : EntityDto<BusinessDto>, IBusiness
    {
        /// <summary>
        /// Name of business
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Tax number of business
        /// </summary>
        public string TaxNumber { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public BusinessDto()
            : base()
        {
        }
    }
}
