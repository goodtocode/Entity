using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{

    #region HealthCheck
    public class HealthCheckMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string path;
        private readonly string connectionString;

        public HealthCheckMiddleware(RequestDelegate nextDelegate, string pathEndpoint, string connectString = "DefaultConnection")
        {
            next = nextDelegate;
            path = pathEndpoint;
            connectionString = connectString;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == path)
            {
                try
                {
                    //using (var db = new SqlConnection("Database=Oops"))
                    //{
                    //    await db.OpenAsync();
                    //    db.Close();
                    //}

                    context.Response.StatusCode = 200;
                    context.Response.ContentLength = 2;
                    await context.Response.WriteAsync("UP");
                }
                catch// (SqlException)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentLength = 20;
                    await context.Response.WriteAsync("SQL Connection Error");
                }
            }
            else
            {
                await this.next(context);
            }
        }
    }

    public static class HealthCheckMiddlewareExtensions
    {
        /// <summary>
        /// Invoke in db-connected service: app.UseHealthCheck("/hc");
        /// </summary>
        /// <param name="builder">IApplicationBuilder</param>
        /// <param name="path">path endpoint to listen</param>
        /// <param name="connectString">Optional connection string name for Sql connection in appsettings.json. Default: DefaultConnection</param>
        /// <returns></returns>
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder builder, string path, string connectString = "DefaultConnection")
        {
            return builder.UseMiddleware<HealthCheckMiddleware>(path, connectString);
        }
    }
    #endregion

    #region UriOptions
    public interface IUriOption
    {
        Uri Url { get; set; }
    }
    public class UriOption : IUriOption
    {
        public Uri Url { get; set; }
    }
    #endregion

    #region IHttpService
    public interface IHttpService
    {
        /// <summary>
        /// Response from the request
        /// </summary>
        HttpResponseMessage Response { get; set; }
    }
    #endregion

    #region HttpSearch
    public interface IHttpSearchService<TDto> : IHttpService
    {
        /// <summary>
        /// Uri of the Query RESTful endpoint
        /// </summary>
        Uri Uri { get; set; }

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
    public class HttpSearchService<TDto> :  IHttpSearchService<TDto> where TDto : new()
    {
        /// <summary>
        /// Uri of the Query RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; } = Defaults.Uri;

        /// <summary>
        /// RESTful endpoint Uri + Querystring parameters, well formed
        /// </summary>
        public Uri FullUri { get; set; } = Defaults.Uri;

        /// <summary>
        /// Response from the request
        /// </summary>
        public HttpResponseMessage Response { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionUrl"></param>
        public HttpSearchService(IOptions<UriOption> optionUrl)
        {
            if(optionUrl.Value.Url != null)
                Uri = optionUrl.Value.Url;
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
            FullUri = new Uri($"{Uri.ToString().RemoveLast("/")}{query.AddFirst("/")}");
            using (var client = new HttpRequestGet<List<TDto>>(FullUri))
            {
                returnData = await client.SendAsync();
                Response = client.Response;
            }
            return await Task.Run(() => returnData);
        }
    }
    #endregion

    #region HttpCrud
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

    public static partial class HttpCrudServicesExtensions
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
        /// <summary>
        /// Uri of the CRUD RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionUrl"></param>
        public HttpCrudService(IOptions<UriOption> optionUrl)
        {
            Uri = optionUrl.Value.Url;
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
    #endregion
}
