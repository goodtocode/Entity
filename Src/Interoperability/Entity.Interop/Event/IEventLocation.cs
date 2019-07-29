//-----------------------------------------------------------------------
// <copyright file="IEventLocation.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Location;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// Event created by a user
    /// </summary>	
    public interface IEventLocation : IEventInfo, ILocationInfo, ILocationTypeKey
    {        
	}
}