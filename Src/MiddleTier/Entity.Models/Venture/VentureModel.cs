//-----------------------------------------------------------------------
// <copyright file="VentureModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Framework.Data;
using System;

namespace Genesys.Entity.Venture
{
    /// <summary>
    /// Flat and thin Venture model used for view only pages
    /// </summary>
    /// <remarks></remarks>
    public class VentureModel : EntityModel<VentureModel>, IVenture
    {
        /// <summary>
        /// VentureId
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// VentureGroupId
        /// </summary>
        public Guid VentureGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// VentureTypeId
        /// </summary>
        public Guid VentureTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Slogan
        /// </summary>
        public string Slogan { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>
        public VentureModel() : base() { }
    }
}
