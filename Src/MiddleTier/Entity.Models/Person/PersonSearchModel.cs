//-----------------------------------------------------------------------
// <copyright file="PersonSearchModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person Search Results
    /// </summary>
    public class PersonSearchModel : PersonModel
    {
        /// <summary>
        /// Search results
        /// </summary>
        public List<PersonModel> Results { get; set; } = new List<PersonModel>();
    }
}