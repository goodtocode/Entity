//// Copyright (c) .NET Foundation. All rights reserved.
//// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//namespace GoodToCode.Framework.Hosting
//{
//    /// <summary>
//    /// Extension methods for setting up MVC services in an <see cref="IServiceCollection" />.
//    /// </summary>
//    public static partial class ServicesExtensions
//    {
//        /// <summary>
//        /// Adds MVC services to the specified <see cref="IServiceCollection" />.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        public static ICrudApiBuilder AddCrudApi(this IServiceCollection services)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            services.AddControllersWithViews();
//            return services.AddRazorPages();
//        }

//        /// <summary>
//        /// Adds MVC services to the specified <see cref="IServiceCollection" />.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <param name="setupAction">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        public static ICrudApiBuilder AddCrudApi(this IServiceCollection services, Action<MvcOptions> setupAction)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            if (setupAction == null)
//            {
//                throw new ArgumentNullException(nameof(setupAction));
//            }

//            var builder = services.AddCrudApi();
//            builder.Services.Configure(setupAction);

//            return builder;
//        }

//        /// <summary>
//        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
//        /// register services used for views or pages.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features with controllers for an API. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>
//        /// on the resulting builder.
//        /// </para>
//        /// <para>
//        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>
//        /// on the resulting builder.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddControllers(this IServiceCollection services)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            var builder = AddControllersCore(services);
//            return new CrudApiBuilder(builder.Services, builder.PartManager);
//        }

//        /// <summary>
//        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
//        /// register services used for views or pages.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features with controllers for an API. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>
//        /// on the resulting builder.
//        /// </para>
//        /// <para>
//        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>
//        /// on the resulting builder.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddControllers(this IServiceCollection services, Action<MvcOptions> configure)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            // This method excludes all of the view-related services by default.
//            var builder = AddControllersCore(services);
//            if (configure != null)
//            {
//                builder.AddCrudApiOptions(configure);
//            }

//            return new CrudApiBuilder(builder.Services, builder.PartManager);
//        }

//        //private static IMvcCoreBuilder AddControllersCore(IServiceCollection services)
//        //{
//        //    // This method excludes all of the view-related services by default.
//        //    return services
//        //        .AddCrudApiCore()
//        //        .AddApiExplorer()
//        //        .AddAuthorization()
//        //        .AddCors()
//        //        .AddDataAnnotations()
//        //        .AddFormatterMappings();
//        //}

//        /// <summary>
//        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
//        /// register services used for pages.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features with controllers with views. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>,
//        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddControllersWithViews(this IServiceCollection services)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            var builder = AddControllersWithViewsCore(services);
//            return new CrudApiBuilder(builder.Services, builder.PartManager);
//        }

//        /// <summary>
//        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
//        /// register services used for pages.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features with controllers with views. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCorsMvcCoreBuilderExtensions.AddCors(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(IMvcCoreBuilder)"/>,
//        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcViewFeaturesMvcCoreBuilderExtensions.AddViews(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcRazorMvcCoreBuilderExtensions.AddRazorViewEngine(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for pages call <see cref="AddRazorPages(IServiceCollection)"/>.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddControllersWithViews(this IServiceCollection services, Action<MvcOptions> configure)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            // This method excludes all of the view-related services by default.
//            var builder = AddControllersWithViewsCore(services);
//            if (configure != null)
//            {
//                builder.AddCrudApiOptions(configure);
//            }

//            return new CrudApiBuilder(builder.Services, builder.PartManager);
//        }

//        private static IMvcCoreBuilder AddControllersWithViewsCore(IServiceCollection services)
//        {
//            var builder = AddControllersCore(services)
//                .AddViews()
//                .AddRazorViewEngine()
//                .AddCacheTagHelper();

//            AddTagHelpersFrameworkParts(builder.PartManager);

//            return builder;
//        }

//        /// <summary>
//        /// Adds services for pages to the specified <see cref="IServiceCollection"/>.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features for pages. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcRazorPagesMvcCoreBuilderExtensions.AddRazorPages(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers for APIs call <see cref="AddControllers(IServiceCollection)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddRazorPages(this IServiceCollection services)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            var builder = AddRazorPagesCore(services);
//            return new CrudApiBuilder(builder.Services, builder.PartManager);
//        }

//        /// <summary>
//        /// Adds services for pages to the specified <see cref="IServiceCollection"/>.
//        /// </summary>
//        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
//        /// <param name="configure">An <see cref="Action{MvcOptions}"/> to configure the provided <see cref="MvcOptions"/>.</param>
//        /// <returns>An <see cref="ICrudApiBuilder"/> that can be used to further configure the MVC services.</returns>
//        /// <remarks>
//        /// <para>
//        /// This method configures the MVC services for the commonly used features for pages. This
//        /// combines the effects of <see cref="MvcCoreServiceCollectionExtensions.AddCrudApiCore(IServiceCollection)"/>,
//        /// <see cref="MvcCoreMvcCoreBuilderExtensions.AddAuthorization(IMvcCoreBuilder)"/>,
//        /// <see cref="MvcDataAnnotationsMvcCoreBuilderExtensions.AddDataAnnotations(IMvcCoreBuilder)"/>,
//        /// <see cref="TagHelperServicesExtensions.AddCacheTagHelper(IMvcCoreBuilder)"/>,
//        /// and <see cref="MvcRazorPagesMvcCoreBuilderExtensions.AddRazorPages(IMvcCoreBuilder)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers for APIs call <see cref="AddControllers(IServiceCollection)"/>.
//        /// </para>
//        /// <para>
//        /// To add services for controllers with views call <see cref="AddControllersWithViews(IServiceCollection)"/>.
//        /// </para>
//        /// </remarks>
//        public static ICrudApiBuilder AddRazorPages(this IServiceCollection services, Action<RazorPagesOptions> configure)
//        {
//            if (services == null)
//            {
//                throw new ArgumentNullException(nameof(services));
//            }

//            var builder = AddRazorPagesCore(services);
//            if (configure != null)
//            {
//                builder.AddRazorPages(configure);
//            }

//            return new CrudApiBuilder(builder.Services, builder.PartManager);

//        }
//    }
//}