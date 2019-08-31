using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Entity.WebClient
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddHttpCrud(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddScoped<IFileService, FileService>();
        }
    }

    public interface IHttpCrudService
    {
        Task<bool> Create(string item);
        Task<bool> Read(string item);
        Task<bool> Update(string item);
        Task<bool> Delete(string item);
    }

    public class HttpCrudService : IHttpCrudService
    {
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public HttpCrudService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> Create(string item)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Read(string item)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Update(string item)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Delete(string item)
        {
            return await Task.Run(() => true);
        }
    }
}