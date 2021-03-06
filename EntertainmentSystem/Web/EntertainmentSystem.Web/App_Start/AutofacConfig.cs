﻿namespace EntertainmentSystem.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using CloudStorage.Dropbox;
    using Controllers;

    using Data;
    using Data.Common;
    using Data.Common.Repositories;
    using Infrastructure.Sanitizer;
    using Services.Forum;
    using Services.Media;
    using Services.Users;
    using Services.Web;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new EntertainmentSystemDbContext())
                .As<DbContext>()
                .InstancePerRequest();

            builder.Register(x => new HttpCacheService())
                .As<ICacheService>()
                .InstancePerRequest();

            builder.Register(x => new IdentifierProvider())
                .As<IIdentifierProvider>()
                .InstancePerRequest();

            builder.Register(x => new HtmlSanitizerAdapter())
                .As<ISanitizer>()
                .InstancePerRequest();

            var usersServicesAssembly = Assembly.GetAssembly(typeof(UserAdminService));
            builder.RegisterAssemblyTypes(usersServicesAssembly).AsImplementedInterfaces();

            var mediaServicesAssembly = Assembly.GetAssembly(typeof(MediaCategoryService));
            builder.RegisterAssemblyTypes(mediaServicesAssembly).AsImplementedInterfaces();

            var forumServicesAssembly = Assembly.GetAssembly(typeof(ForumPostService));
            builder.RegisterAssemblyTypes(forumServicesAssembly).AsImplementedInterfaces();

            var dropboxCloudStorage = Assembly.GetAssembly(typeof(DropboxCloudStorage));
            builder.RegisterAssemblyTypes(dropboxCloudStorage).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}
