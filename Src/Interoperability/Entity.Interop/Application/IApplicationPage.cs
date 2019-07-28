
//-----------------------------------------------------------------------
// <copyright file="IApplicationInfo.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extras.Net;
using Genesys.Entity.Device;

namespace Genesys.Entity.Application
{
    /// <summary>
    /// Application critical process information such as common pages, web services and Application table data
    /// Often a singleton/static object, one per application project
    /// </summary>    
    public interface IApplicationPage : IApplication
    {
        /// <summary>
        /// Entry point Screen (Typically login screen)
        /// </summary>
        Uri LandingPage { get; }

        /// <summary>
        /// Home dashboard screen
        /// </summary>
        Uri HomePage { get; }

        /// <summary>
        /// Error screen
        /// </summary>
        Uri ErrorPage { get; }
    }
}