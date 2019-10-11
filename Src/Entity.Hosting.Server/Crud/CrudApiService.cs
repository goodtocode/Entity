using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// Extensions to IServiceCollection
    /// </summary>
    public static partial class CrudApiServicesExtensions
    {
        /// <summary>
        /// Adds Http-based CRUD services to .NET Core Dependency Injection
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCrudApi<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<ICrudApiService<TDto>, CrudApiService<TDto>>();
        }
    }

    /// <summary>
    /// Provides Http-based CRUD services based on:
    ///  1. A single set of RESTful endpoints (i.e. configuration["AppSettings:MyWebService"])
    ///  2. A single Type of Dto in requests/responses
    /// </summary>
    /// <typeparam name="TDto">Type of Dto in requests/responses</typeparam>
    public class CrudApiService<TDto> : ICrudApiService<TDto> where TDto : new()
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="endpoints"></param>
        public CrudApiService(IOptions<CrudApiOptions> endpoints)
        {
        }

        
    }
}