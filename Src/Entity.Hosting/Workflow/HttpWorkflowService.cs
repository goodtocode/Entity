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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddHttpWorkflow(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddScoped<IFileService, FileService>();
        }
    }

    public interface IHttpWorkflowService
    {
        Task<bool> ProcessAsync(string path, string file, byte[] content);
    }

    public class HttpWorkflowService : IHttpWorkflowService
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public HttpWorkflowService(IHostingEnvironment environment)
        {
            this.hostingEnvironment = environment;
        }

        public async Task<bool> ProcessAsync(string path, string file, byte[] content)
        {
            return await Task.Run(() => true);
        }
    }
}