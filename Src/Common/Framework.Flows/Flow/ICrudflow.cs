//-----------------------------------------------------------------------
// <copyright file="ICrudflow.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace GoodToCode.Framework.Flow
{
    /// <summary>
    /// CRUD interface for a Crudflow class that Creates, Reads, Updates and Deletes a TEntity
    /// </summary>
    /// <typeparam name="TEntity">Type of class supporting CRUD methods</typeparam>
    public interface ICrudflow<TEntity>
    {
        /// <summary>
        /// Create the object
        /// </summary>
        /// <returns></returns>
        TEntity Create();

        /// <summary>
        /// Retrieve the object
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Read(Predicate<TEntity> predicate);

        /// <summary>
        /// Update the object
        /// </summary>
        TEntity Update();

        /// <summary>
        /// Delete the object
        /// </summary>
        TEntity Delete();
    }
}
