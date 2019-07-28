//-----------------------------------------------------------------------
// <copyright file="IEntityDetail.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Detail;
using Genesys.Framework.Data;

namespace Genesys.Entity
{
    /// <summary>
    /// Detail of an Entity, like parking, tickets, etc.
    /// </summary>
    public interface IEntityDetail : IEntityKey, IDetail
    {
    }
}
