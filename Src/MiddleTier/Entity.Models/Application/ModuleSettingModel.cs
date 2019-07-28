//-----------------------------------------------------------------------
// <copyright file="ModuleSettingModel.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Genesys.Extensions;
using Genesys.Framework.Data;

namespace Genesys.Entity.Application
{
    /// <summary>
    /// ModuleSetting Screen and Transport Model
    /// </summary>    
    public class ModuleSettingModel : EntityModel<ModuleSettingModel>
    {
        /// <summary>
        /// ApplicationId
        /// </summary>
        public int ApplicationId { get; set; } = Defaults.Integer;

        /// <summary>
        /// SettingId
        /// </summary>
        public int SettingId { get; set; } = Defaults.Integer;

        /// <summary>
        /// SettingTypeId
        /// </summary>
        public int SettingTypeId { get; set; } = Defaults.Integer;

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; } = Defaults.String;
    }
}
