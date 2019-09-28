
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