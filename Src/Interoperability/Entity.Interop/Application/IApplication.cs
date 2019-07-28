//-----------------------------------------------------------------------
// <copyright file="IApplication.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Name;

namespace Genesys.Entity.Application
{
    /// <summary>
    /// Global class containing global information for an application
    /// Often a singleton/static object, one per application project
    /// </summary>    
    public interface IApplication : INameKey
    {
        /// <summary>
        /// Id of the business owning the application
        /// </summary>
        Guid BusinessKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PrivacyUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string TermsUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime TermsRevisedDate { get; set; }
    }
}