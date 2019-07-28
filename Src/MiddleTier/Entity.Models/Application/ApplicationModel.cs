//-----------------------------------------------------------------------
// <copyright file="ApplicationModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Framework.Name;
using Genesys.Extensions;

namespace Genesys.Entity.Application
{
	/// <summary>
	/// Application
	/// </summary>
	
	public class ApplicationModel : NameIdModel, IApplication
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
