//-----------------------------------------------------------------------
// <copyright file="ISchedule.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Framework.Name;

namespace GoodToCode.Entity.Schedule
{
    /// <summary>
    /// A schedule. Schedule = Resource + TimeRange + Location
    /// </summary>    
    public interface ISchedule : INameDescription
    {
    }
}
