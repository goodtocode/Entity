//-----------------------------------------------------------------------
// <copyright file="IActivitySessionflow.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------

namespace Genesys.Entity.Activity
{
    /// <summary>
    /// Session flow activity data access object
    /// </summary>    
    public interface IActivitySessionflow : IActivityFlow
    {
        /// <summary>
        /// List of KeyValuePair string items. Properties are Key and Value.
        /// </summary>
        string SessionflowData { get; }
    }
}
