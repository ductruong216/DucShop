using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using ShopOnline.Data;
using ShopOnline.Data.Parttern;
using ShopOnline.Data.Repositories;
using ShopOnline.Service;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ShopOnline.Web.App_Start.Startup))]

namespace ShopOnline.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutoFac(app);
        }

        private void ConfigAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // AutoFac.MVC5
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // AutoFac.WebApi2
            // Register WebAPI controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register interface
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<ShopDbContext>().AsSelf().InstancePerRequest();

            // Repository
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(_ => _.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
              .Where(_ => _.Name.EndsWith("Service"))
              .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}