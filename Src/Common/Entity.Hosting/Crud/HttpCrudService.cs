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
using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    public static partial class ServicesExtensions
    {
        /// <summary>
        /// Adds Http-based CRUD services to .NET Core Dependency Injection
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpCrud<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<IHttpCrudService<TDto>, HttpCrudService<TDto>>();
        }
    }

    /// <summary>
    /// Provides Http-based CRUD services based on:
    ///  1. A single set of RESTful endpoints (i.e. configuration["AppSettings:MyWebService"])
    ///  2. A single Type of Dto in requests/responses
    /// </summary>
    /// <typeparam name="TDto">Type of Dto in requests/responses</typeparam>
    public class HttpCrudService<TDto> : IHttpCrudService<TDto> where TDto : new()
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        private string uriRoot => configuration["AppSettings:MyWebService"];
        private string controllerPath => typeof(TDto).Name.RemoveLast("Model").RemoveLast("Info");

        /// <summary>
        /// Uri of the CRUD RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public HttpCrudService(IConfiguration config)
        {
            configuration = config;
            Uri = new Uri(uriRoot.AddLast("/") + controllerPath.RemoveFirst("/").RemoveLast("/"));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionSearch"></param>
        public HttpCrudService(IOptions<UriOption> optionSearch)
        {
            Uri = optionSearch.Value.Url;
        }

        /// <summary>
        /// Creates an item in the system
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Created item, with updated Id/Key (if applicable)</returns>
        public async Task<TDto> CreateAsync(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPut<TDto>(Uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        public async Task<TDto> ReadAsync(string query)
        {
            TDto returnData;
            query = query.Replace("//", "/ /");
            var uriQuery = new Uri($"{Uri.ToString().RemoveLast("/")}{query.AddFirst("/")}");
            using (var client = new HttpRequestGet<TDto>(uriQuery))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="id">Id of the item to return</param>
        /// <returns>Item from the system</returns>
        public async Task<TDto> ReadAsync(int id)
        {
            TDto returnData;
            var uriId = new Uri($"{Uri.ToString().RemoveLast("/")}/{id.ToString()}");
            using (var client = new HttpRequestGet<TDto>(uriId))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="key">Key of the item to return</param>
        /// <returns>Item from the system</returns>
        public async Task<TDto> ReadAsync(Guid key)
        {
            TDto returnData;
            var uriKey = new Uri($"{Uri.ToString().RemoveLast("/")}/{key.ToString()}");
            using (var client = new HttpRequestGet<TDto>(uriKey))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="item">item to update</param>
        /// <returns>Item from the system</returns>
        public async Task<TDto> UpdateAsync(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPost<TDto>(Uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        /// <summary>
        /// Deletes an item in the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="item">item to delete</param>
        /// <returns>Item from the system</returns>
        public async Task<bool> DeleteAsync(TDto item)
        {
            bool returnData;
            using (var client = new HttpRequestDelete(Uri))
            {
                returnData = await client.DeleteAsync();
            }
            return await Task.Run(() => returnData);
        }
    }
}