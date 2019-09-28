
using System;
using GoodToCode.Framework.Name;
using GoodToCode.Extensions;

namespace GoodToCode.Entity.Application
{
	/// <summary>
	/// Application
	/// </summary>
	
	public class ApplicationDto : NameIdDto, IApplication
    {
        /// <summary>
        /// Id of business owning this application
        /// </summary>
        public Guid BusinessKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Url of the privacy policy
        /// </summary>
        public string PrivacyUrl { get; set; } = Defaults.String;

        /// <summary>
        /// Date terms were revised. Must show terms again if user has not accepted current terms.
        /// </summary>
        public string TermsUrl { get; set; } = Defaults.String;

        /// <summary>
        /// Date terms were revised. Must show terms again if user has not accepted current terms.
        /// </summary>
        public DateTime TermsRevisedDate { get; set; } = Defaults.Date;
    }
}
