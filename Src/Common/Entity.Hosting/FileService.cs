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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddFileIo(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddSingleton<IFileService, FileService>();
        }
    }

    public interface IFileService
    {
        Task<bool> Save(string path, string file, byte[] content);
    }

    public class FileService : IFileService
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public FileService(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public async Task<bool> Save(string path, string file, byte[] content)
        {
            Directory.CreateDirectory(Path.Combine(path));
            File.AppendAllText(Path.Combine(path, file), content.ToString());
            return await Task.Run(() => true);
        }
    }
}