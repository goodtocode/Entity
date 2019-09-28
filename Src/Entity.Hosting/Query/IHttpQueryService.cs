using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    /// <summary>
    /// HttpSearchService contract
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IHttpQueryService<TDto> : IHttpService
    {
        /// <summary>
        /// Querystring parameters, well formed
        /// </summary>
        Uri FullUri { get; set; }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        Task<List<TDto>> QueryAsync(string query);
    }
}