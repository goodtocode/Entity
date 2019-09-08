//-----------------------------------------------------------------------
// <copyright file="HttpRequestDelete.cs" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    /// <summary>
    /// HttpCrudService contract
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IHttpCrudService<TDto>
    {
        /// <summary>
        /// Creates an item in the system
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Created item, with updated Id/Key (if applicable)</returns>
        Task<TDto> CreateAsync(TDto item);

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        Task<TDto> ReadAsync(string query);

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="id">Id of the item to return</param>
        /// <returns>Item from the system</returns>
        Task<TDto> ReadAsync(int id);

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="key">Key of the item to return</param>
        /// <returns>Item from the system</returns>
        Task<TDto> ReadAsync(Guid key);

        /// <summary>
        /// Updates an item in the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="item">item to update</param>
        /// <returns>Item from the system</returns>
        Task<TDto> UpdateAsync(TDto item);

        /// <summary>
        /// Deletes an item in the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="item">item to delete</param>
        /// <returns>Item from the system</returns>
        Task<bool> DeleteAsync(TDto item);
    }
}