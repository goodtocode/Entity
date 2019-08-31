using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Entity.WebClient
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddHttpWorkflow(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) // Defense
                throw new ArgumentNullException(nameof(services));

            // Add service
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
            Directory.CreateDirectory(Path.Combine(path));
            File.AppendAllText(Path.Combine(path, file), content.ToString());
            return await Task.Run(() => true);
        }
    }
}