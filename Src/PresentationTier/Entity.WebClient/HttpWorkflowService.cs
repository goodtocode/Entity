using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Entity.WebClient
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddHttpWorkflow(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddScoped<IFileService, FileService>();
        }
    }

    public interface IHttpWorkflowService
    {
        Task<bool> Process(string path, string file, byte[] content);
    }

    public class HttpWorkflowService : IHttpWorkflowService
    {
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public HttpWorkflowService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> Process(string path, string file, byte[] content)
        {
            return await Task.Run(() => true);
        }
    }
}