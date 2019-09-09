//-----------------------------------------------------------------------
// <copyright file="HttpSearchService.cs" company="GoodToCode">
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
using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    /// <summary>
    /// Extensions for Services
    /// </summary>
    public static partial class HttpSearchServicesExtensions
    {
        /// <summary>
        /// Adds Http-based Query services to .NET Core Dependency Injection
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpSearch<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<IHttpSearchService<TDto>, HttpSearchService<TDto>>();
        }
    }

    /// <summary>
    /// Provides Http-based Query services based on:
    ///  1. A single set of RESTful endpoints. Default is: configuration["AppSettings:MyWebService"]
    ///  2. A single Type of Dto in requests/responses. TDto
    /// </summary>
    /// <typeparam name="TDto">Type of Dto in requests/responses</typeparam>
    public class HttpSearchService<TDto> : IHttpSearchService<TDto> where TDto : new()
    {
        /// <summary>
        /// Uri of the Query RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionSearch"></param>
        public HttpSearchService(IOptions<UriOption> optionSearch)
        {
            Uri = optionSearch.Value.Url;
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        public async Task<List<TDto>> QueryAsync(string query)
        {
            List<TDto> returnData;
            query = query.Replace("//", "/ /");
            var uriQuery = new Uri($"{Uri.ToString().RemoveLast("/")}{query.AddFirst("/")}");
            using (var client = new HttpRequestGet<List<TDto>>(uriQuery))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }
    }
}