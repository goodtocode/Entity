
using System;
using GoodToCode.Extensions.Net;
using GoodToCode.Entity.Device;

namespace GoodToCode.Entity.Application
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