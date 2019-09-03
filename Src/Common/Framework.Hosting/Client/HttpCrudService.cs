using GoodToCode.Extensions;
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
        Task<TDto> Read(string query);
        Task<TDto> Read(int id);
        Task<TDto> Read(Guid key);
        Task<TDto> Update(TDto item);
        Task<string> Delete(TDto item);
    }

    public class HttpCrudService<TDto> : IHttpCrudService<TDto> where TDto : new()
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        private string uriRoot => configuration["AppSettings:MyWebService"];
        private string controllerPath => typeof(TDto).Name.RemoveLast("Model").RemoveLast("Info");
        public Uri Uri { get; set; }

        public HttpCrudService(IHostingEnvironment environment, IConfiguration config)
        {
            hostingEnvironment = environment;
            configuration = config;
            Uri = new Uri(uriRoot.AddLast("/") + controllerPath.RemoveFirst("/").RemoveLast("/"));
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

        public async Task<TDto> Read(string query)
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

        public async Task<TDto> Read(int id)
        {
            TDto returnData;
            var uriId = new Uri($"{Uri.ToString().RemoveLast("/")}/{id.ToString()}");
            using (var client = new HttpRequestGet<TDto>(uriId))
            {
                returnData = await client.SendAsync();
            }
            return await Task.Run(() => returnData);
        }

        public async Task<TDto> Read(Guid key)
        {
            TDto returnData;
            var uriKey = new Uri($"{Uri.ToString().RemoveLast("/")}/{key.ToString()}");
            using (var client = new HttpRequestGet<TDto>(uriKey))
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