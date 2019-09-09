using GoodToCode.Extensions;
using GoodToCode.Extensions.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
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
    public interface IHttpQueryService1<TDto>
    {
        /// <summary>
        /// Reads an item from the system
        /// Constrained to 1 item. Search using Queryflow
        /// </summary>
        /// <param name="query">Querystring parameters that will result in one item returned</param>
        /// <returns>Item from the system</returns>
        Task<List<TDto>> QueryAsync(string query);
    }
    public static partial class ServicesExtensions
    {
        /// <summary>
        /// Adds Http-based Query services to .NET Core Dependency Injection
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpQuery1<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<IHttpQueryService1<TDto>, HttpQueryService1<TDto>>();
        }
    }

    /// <summary>
    /// Provides Http-based Query services based on:
    ///  1. A single set of RESTful endpoints (i.e. configuration["AppSettings:MyWebService"])
    ///  2. A single Type of Dto in requests/responses
    /// </summary>
    /// <typeparam name="TDto">Type of Dto in requests/responses</typeparam>
    public class HttpQueryService1<TDto> : IHttpQueryService1<TDto> where TDto : new()
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        private string uriRoot => configuration["AppSettings:MyWebService"];
        private string controllerPath => typeof(TDto).Name.RemoveLast("Model").RemoveLast("Info");

        /// <summary>
        /// Uri of the Query RESTful endpoint
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="config"></param>
        public HttpQueryService1(IHostingEnvironment environment, IConfiguration config)
        {
            hostingEnvironment = environment;
            configuration = config;
            Uri = new Uri(uriRoot.AddLast("/") + controllerPath.RemoveFirst("/").RemoveLast("/"));
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
