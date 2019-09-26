using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Hosting
{
    public class DbHealthCheckMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string path;
        private readonly string connectionString;

        public DbHealthCheckMiddleware(RequestDelegate nextDelegate, string pathEndpoint, string connectString = "DefaultConnection")
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

    public static class DbHealthCheckMiddlewareExtensions
    {
        /// <summary>
        /// Invoke in db-connected service: app.UseHealthCheck("/hc");
        /// </summary>
        /// <param name="builder">IApplicationBuilder</param>
        /// <param name="path">path endpoint to listen</param>
        /// <param name="connectString">Optional connection string name for Sql connection in appsettings.json. Default: DefaultConnection</param>
        /// <returns></returns>
        public static IApplicationBuilder UseDbHealthCheck(this IApplicationBuilder builder, string path, string connectString = "DefaultConnection")
        {
            return builder.UseMiddleware<DbHealthCheckMiddleware>(path, connectString);
        }
    }
}
