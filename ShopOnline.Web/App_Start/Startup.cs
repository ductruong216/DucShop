using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using ShopOnline.Data;
using ShopOnline.Data.Parttern;
using ShopOnline.Data.Repositories;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static ShopOnline.Web.App_Start.IdentityConfig;

namespace ShopOnline.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutoFac(app);
            ConfigureAuth(app);
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

            //ASPNet Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
        }
    }
}