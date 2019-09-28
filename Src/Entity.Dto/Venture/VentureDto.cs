using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using System;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Flat and thin Venture model used for view only pages
    /// </summary>
    /// <remarks></remarks>
    public class VentureDto : EntityDto<VentureDto>, IVenture
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
        public VentureDto() : base() { }
    }
}
