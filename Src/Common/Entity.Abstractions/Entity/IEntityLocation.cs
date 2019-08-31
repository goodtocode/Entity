//-----------------------------------------------------------------------
// <copyright file="IEntityLocation.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Location;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity
{
    /// <summary>
    /// A entity's properties, like gender, social preferences, etc.
    /// </summary>
    public interface IEntityLocation : IEntityKey, ILocationInfo
	{
	}
}
