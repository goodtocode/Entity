//-----------------------------------------------------------------------
// <copyright file="IEventOption.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Option;

namespace Genesys.Entity.Event
{
	/// <summary>
	/// A entity's properties, like gender, social preferences, etc.
	/// </summary>
    public interface IEventOption : IEventKey, IOptionKey
	{
	}
}
