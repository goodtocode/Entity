using GoodToCode.Framework.Hosting.Server;
using GoodToCode.Entity.Person;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using GoodToCode.Framework.Repository;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Framework.Entity;
using GoodToCode.Entity.Event;

namespace GoodToCode.Entity.WebServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",

                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API Discovery", Version = "v1" });
            });

            var crudControllers = new List<CrudApiRoute>() {
                new CrudApiRoute(typeof(PersonInfo), "api/Person"),
                new CrudApiRoute(typeof(EventInfo), "api/Event")
            };
            services
                .AddMvc(o => o.Conventions.Add(
                  new CrudApiControllerRouteConvention(crudControllers)))
                    .ConfigureApplicationPartManager(m =>
                        m.FeatureProviders.Add(new CrudApiControllerFeatureProvider(crudControllers)
                ))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver
                        = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });
            services.AddApplicationInsightsTelemetry();

            // Must add DB Context for each controller
            services.AddDbContext<EntityWriter<PersonInfo>>();
            services.AddTransient<IEntityConfiguration<PersonInfo>, PersonInfoSPConfig>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Discovery");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}