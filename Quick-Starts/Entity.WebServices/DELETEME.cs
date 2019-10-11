// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GoodToCode.Entity.Hosting.Server
{
    /// <summary>
    /// Extension methods for setting up MVC services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class MvcServiceCollectionExtensions
    {
        /// <summary>
        /// Adds MVC services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        public static IMvcBuilder AddMvc(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddControllersWithViews();
            return services.AddRazorPages();
        }

        /// <summary>
        /// Adds MVC services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        public static IMvcBuilder AddMvc(this IServiceCollection services, Action<MvcOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            var builder = services.AddMvc();
            builder.Services.Configure(setupAction);

            return builder;
        }

        /// <summary>
        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for views or pages.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features with controllers for an API. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>
        /// on the resulting builder.
        /// </para>
        /// <para>
        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>
        /// on the resulting builder.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddControllers(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = AddControllersCore(services);
            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        /// <summary>
        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for views or pages.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features with controllers for an API. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>
        /// on the resulting builder.
        /// </para>
        /// <para>
        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>
        /// on the resulting builder.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddControllers(this IServiceCollection services, Action<MvcOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // This method excludes all of the view-related services by default.
            var builder = AddControllersCore(services);
            if (configure != null)
            {
                builder.AddMvcOptions(configure);
            }

            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        private static IMvcCoreBuilder AddControllersCore(IServiceCollection services)
        {
            // This method excludes all of the view-related services by default.
            return services
                .AddMvcCore()
                .AddApiExplorer()
                .AddAuthorization()
                .AddCors()
                .AddDataAnnotations()
                .AddFormatterMappings();
        }

        /// <summary>
        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for pages.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features with controllers with views. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>,
        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
        /// <see cref="MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddControllersWithViews(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = AddControllersWithViewsCore(services);
            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        /// <summary>
        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for pages.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features with controllers with views. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>,
        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
        /// <see cref="MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddControllersWithViews(this IServiceCollection services, Action<MvcOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // This method excludes all of the view-related services by default.
            var builder = AddControllersWithViewsCore(services);
            if (configure != null)
            {
                builder.AddMvcOptions(configure);
            }

            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        private static IMvcCoreBuilder AddControllersWithViewsCore(IServiceCollection services)
        {
            var builder = AddControllersCore(services)
                .AddViews()
                .AddRazorViewEngine()
                .AddCacheTagHelper();

            AddTagHelpersFrameworkParts(builder.PartManager);

            return builder;
        }

        /// <summary>
        /// Adds services for pages to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features for pages. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcRazorPagesMvcCoreBuilderExtensions.AddRazorPages(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers for APIs call <see cref="AddControllers(IServiceCollection)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddRazorPages(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = AddRazorPagesCore(services);
            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        /// <summary>
        /// Adds services for pages to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
        /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
        /// <remarks>
        /// <para>
        /// This method configures the MVC services for the commonly used features for pages. This
        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddMvcCore(IServiceCollection)"/>,
        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
        /// and <see cref="MvcRazorPagesMvcCoreBuilderExtensions.AddRazorPages(IMvcCoreBuilder)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers for APIs call <see cref="AddControllers(IServiceCollection)"/>.
        /// </para>
        /// <para>
        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>.
        /// </para>
        /// </remarks>
        public static IMvcBuilder AddRazorPages(this IServiceCollection services, Action<RazorPagesOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = AddRazorPagesCore(services);
            if (configure != null)
            {
                builder.AddRazorPages(configure);
            }

            return new MvcBuilder(builder.Services, builder.PartManager);

        }

        private static IMvcCoreBuilder AddRazorPagesCore(IServiceCollection services)
        {
            // This method includes the minimal things controllers need. It's not really feasible to exclude the services
            // for controllers.
            var builder = services
                .AddMvcCore()
                .AddAuthorization()
                .AddDataAnnotations()
                .AddRazorPages()
                .AddCacheTagHelper();

            AddTagHelpersFrameworkParts(builder.PartManager);

            return builder;
        }

        internal static void AddTagHelpersFrameworkParts(ApplicationPartManager partManager)
        {
            var mvcTagHelpersAssembly = typeof(InputTagHelper).GetTypeInfo().Assembly;
            if (!partManager.ApplicationParts.OfType<AssemblyPart>().Any(p => p.Assembly == mvcTagHelpersAssembly))
            {
                partManager.ApplicationParts.Add(new FrameworkAssemblyPart(mvcTagHelpersAssembly));
            }

            var mvcRazorAssembly = typeof(UrlResolutionTagHelper).GetTypeInfo().Assembly;
            if (!partManager.ApplicationParts.OfType<AssemblyPart>().Any(p => p.Assembly == mvcRazorAssembly))
            {
                partManager.ApplicationParts.Add(new FrameworkAssemblyPart(mvcRazorAssembly));
            }
        }

        [DebuggerDisplay("{Name}")]
        private class FrameworkAssemblyPart : AssemblyPart, ICompilationReferencesProvider
        {
            public FrameworkAssemblyPart(Assembly assembly)
                : base(assembly)
            {
            }

            IEnumerable<string> ICompilationReferencesProvider.GetReferencePaths() => Enumerable.Empty<string>();
        }
    }

    /// <summary>
    /// Extensions for configuring MVC using an <see cref="IMvcCoreBuilder"/>.
    /// </summary>
    public static class MvcCoreMvcCoreBuilderExtensions
    {
        /// <summary>
        /// Registers an action to configure <see cref="MvcOptions"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setupAction">An <see cref="Action{MvcOptions}"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddMvcOptions(
            this IMvcCoreBuilder builder,
            Action<MvcOptions> setupAction)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            builder.Services.Configure(setupAction);
            return builder;
        }

        /// <summary>
        /// Configures <see cref="JsonOptions"/> for the specified <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <param name="configure">An <see cref="Action"/> to configure the <see cref="JsonOptions"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        //public static IMvcCoreBuilder AddJsonOptions(
        //    this IMvcCoreBuilder builder,
        //    Action<JsonOptions> configure)
        //{
        //    if (builder == null)
        //    {
        //        throw new ArgumentNullException(nameof(builder));
        //    }

        //    if (configure == null)
        //    {
        //        throw new ArgumentNullException(nameof(configure));
        //    }

        //    builder.Services.Configure(configure);
        //    return builder;
        //}

        /// <summary>
        /// Adds services to support <see cref="FormatterMappings"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        public static IMvcCoreBuilder AddFormatterMappings(this IMvcCoreBuilder builder)
        {
            AddFormatterMappingsServices(builder.Services);
            return builder;
        }

        /// <summary>
        /// Configures <see cref="FormatterMappings"/> for the specified <paramref name="setupAction"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setupAction">An <see cref="Action"/> to configure the <see cref="FormatterMappings"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        public static IMvcCoreBuilder AddFormatterMappings(
            this IMvcCoreBuilder builder,
            Action<FormatterMappings> setupAction)
        {
            AddFormatterMappingsServices(builder.Services);

            if (setupAction != null)
            {
                builder.Services.Configure<MvcOptions>((options) => setupAction(options.FormatterMappings));
            }

            return builder;
        }

        // Internal for testing.
        internal static void AddFormatterMappingsServices(IServiceCollection services)
        {
            services.TryAddSingleton<FormatFilter, FormatFilter>();
        }

        /// <summary>
        /// Configures authentication and authorization services for <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddAuthorization(this IMvcCoreBuilder builder)
        {
            AddAuthorizationServices(builder.Services);
            return builder;
        }

        /// <summary>
        /// Configures authentication and authorization services for <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setupAction">An <see cref="Action"/> to configure the <see cref="AuthorizationOptions"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddAuthorization(
            this IMvcCoreBuilder builder,
            Action<AuthorizationOptions> setupAction)
        {
            AddAuthorizationServices(builder.Services);

            if (setupAction != null)
            {
                builder.Services.Configure(setupAction);
            }

            return builder;
        }

        // Internal for testing.
        internal static void AddAuthorizationServices(IServiceCollection services)
        {
            services.AddAuthenticationCore();
            services.AddAuthorization();

            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IApplicationModelProvider, AuthorizationApplicationModelProvider>());
        }

        /// <summary>
        /// Registers discovered controllers as services in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddControllersAsServices(this IMvcCoreBuilder builder)
        {
            var feature = new ControllerFeature();
            builder.PartManager.PopulateFeature(feature);

            foreach (var controller in feature.Controllers.Select(c => c.AsType()))
            {
                builder.Services.TryAddTransient(controller, controller);
            }

            builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            return builder;
        }

        /// <summary>
        /// Adds an <see cref="ApplicationPart"/> to the list of <see cref="ApplicationPartManager.ApplicationParts"/> on the
        /// <see cref="IMvcCoreBuilder.PartManager"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="assembly">The <see cref="Assembly"/> of the <see cref="ApplicationPart"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddApplicationPart(this IMvcCoreBuilder builder, Assembly assembly)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            builder.ConfigureApplicationPartManager(manager =>
            {
                var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
                foreach (var applicationPart in partFactory.GetApplicationParts(assembly))
                {
                    manager.ApplicationParts.Add(applicationPart);
                }
            });

            return builder;
        }

        /// <summary>
        /// Configures the <see cref="ApplicationPartManager"/> of the <see cref="IMvcCoreBuilder.PartManager"/> using
        /// the given <see cref="Action{ApplicationPartManager}"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setupAction">The <see cref="Action{ApplicationPartManager}"/></param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder ConfigureApplicationPartManager(
            this IMvcCoreBuilder builder,
            Action<ApplicationPartManager> setupAction)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            setupAction(builder.PartManager);

            return builder;
        }

        /// <summary>
        /// Configures <see cref="ApiBehaviorOptions"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setupAction">The configure action.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder ConfigureApiBehaviorOptions(
            this IMvcCoreBuilder builder,
            Action<ApiBehaviorOptions> setupAction)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            builder.Services.Configure(setupAction);

            return builder;
        }

        /// <summary>
        /// Sets the <see cref="CompatibilityVersion"/> for ASP.NET Core MVC for the application.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="version">The <see cref="CompatibilityVersion"/> value to configure.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder SetCompatibilityVersion(this IMvcCoreBuilder builder, CompatibilityVersion version)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.Configure<MvcCompatibilityOptions>(o => o.CompatibilityVersion = version);
            return builder;
        }
    }
}