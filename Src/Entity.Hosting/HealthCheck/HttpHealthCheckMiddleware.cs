﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    public class HttpHealthCheckMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string path;
        private readonly string url;

        public HttpHealthCheckMiddleware(RequestDelegate nextDelegate, string endpointToListen, string urlToCheck = "http://localhost")
        {
            next = nextDelegate;
            path = endpointToListen;
            url = urlToCheck;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == path)
            {
                try
                {
                    // Check the URL

                    context.Response.StatusCode = 200;
                    context.Response.ContentLength = 2;
                    await context.Response.WriteAsync("UP");
                }
                catch// (SqlException)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentLength = 20;
                    await context.Response.WriteAsync("HTTP_GET Error");
                }
            }
            else
            {
                await this.next(context);
            }
        }
    }

    public static class HttpHealthCheckMiddlewareExtensions
    {
        /// <summary>
        /// Invoke in db-connected service: app.UseHealthCheck("/hc");
        /// </summary>
        /// <param name="builder">IApplicationBuilder</param>
        /// <param name="path">path endpoint to listen</param>
        /// <param name="url">Optional connection string name for Sql connection in appsettings.json. Default: DefaultConnection</param>
        /// <returns></returns>
        public static IApplicationBuilder UseHttpHealthCheck(this IApplicationBuilder builder, string path, string url = "DefaultConnection")
        {
            return builder.UseMiddleware<HttpHealthCheckMiddleware>(path, url);
        }
    }
}