using GoodToCode.Extras.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Framework.Hosting
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddHttpCrud<TDto>(this IServiceCollection services) where TDto : new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddTransient<IHttpCrudService<TDto>, HttpCrudService<TDto>>();
        }
    }

    public interface IHttpCrudService<TDto>
    {
        Task<TDto> Create(TDto item);
        Task<TDto> Read(TDto item);
        Task<TDto> Update(TDto item);
        Task<string> Delete(TDto item);
    }

    public class HttpCrudService<TDto> : IHttpCrudService<TDto> where TDto : new()
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        private Uri Uri { get { return new Uri(configuration["AppSettings:MyWebService"]); } }

        public HttpCrudService(IHostingEnvironment environment, IConfiguration config)
        {
            hostingEnvironment = environment;
            configuration = config;
        }

        public async Task<TDto> Create(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPut<TDto>(Uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<TDto> Read(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestGet<TDto>(Uri))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<TDto> Update(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPost<TDto>(Uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<string> Delete(TDto item)
        {
            string returnData;
            using (var client = new HttpRequestDelete(Uri))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }
    }
}