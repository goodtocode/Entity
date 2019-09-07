//-----------------------------------------------------------------------
// <copyright file="PropertyGroup.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Option
{
    /// <summary>
    /// PropertyGroup
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class OptionGroup : ActiveRecordValue<OptionGroup>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public OptionGroup() : base()
		{
		}
	}
}
