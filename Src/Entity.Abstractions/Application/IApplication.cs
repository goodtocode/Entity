
using System;
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Application
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