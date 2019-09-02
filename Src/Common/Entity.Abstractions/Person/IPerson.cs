﻿//-----------------------------------------------------------------------
// <copyright file="IPerson.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Person
    /// </summary>        
    public interface IPerson : IGenderId
    {
        /// <summary>
        /// FirstName
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// MiddleName
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// BirthDate
        /// </summary>
        DateTime BirthDate { get; set; }
    }
}
