using GoodToCode.Extras.Net;
using Microsoft.AspNetCore.Hosting;
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

            return services.AddScoped<IHttpCrudService<TDto>, HttpCrudService<TDto>>();
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
        private readonly Uri uri;

        public HttpCrudService(IHostingEnvironment environment, string url)
        {
            hostingEnvironment = environment;
            uri = new Uri(url);
        }

        public async Task<TDto> Create(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPut<TDto>(uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<TDto> Read(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestGet<TDto>(uri))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<TDto> Update(TDto item)
        {
            TDto returnData;
            using (var client = new HttpRequestPost<TDto>(uri, item))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<string> Delete(TDto item)
        {
            string returnData;
            using (var client = new HttpRequestDelete(uri))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }
    }
}