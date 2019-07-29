//-----------------------------------------------------------------------
// <copyright file="VentureOptionModel.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using GoodToCode.Entity.Option;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// For one selection in a OptionGroup's properties
    /// </summary>
    public class VentureOptionModel : EntityModel<VentureOptionModel>, IVentureOption
    {
        private readonly OptionGroupModel _group = new OptionGroupModel();
        private readonly IQueryable<OptionModel> _selections;

        /// <summary>
        /// VentureKey regarding this Option
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Possible selections
        /// </summary>
        public IQueryable<OptionModel> Selections
        {
            get { return _selections; }
        }
        
        /// <summary>
        /// Group
        /// </summary>
        public OptionGroupModel Group
        {
            get { return _group; }
        }

        /// <summary>
        /// Option whose value is being selected
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Selected value
        /// </summary>
        public string Value
        {
            get { return Selections.Where(x => x.Key == this.OptionKey).FirstOrDefault().Name; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureOptionModel()
            : base()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureOptionModel(IQueryable<OptionModel> selections)
            : base()
        {
            _selections = selections;
        }    }   
}