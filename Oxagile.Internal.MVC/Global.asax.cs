using Castle.Windsor;
using Castle.Windsor.Installer;
using Oxagile.Internal.MVC.DALCF;
using Oxagile.Internal.MVC.WindsorResolver;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace Oxagile.Internal.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            Database.SetInitializer(new EntitiesDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
        }
        private static void BootstrapContainer()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new WindsorFluentValidatorFactory(_container);
            });
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}
