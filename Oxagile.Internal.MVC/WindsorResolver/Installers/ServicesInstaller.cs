using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Oxagile.Internal.MVC.Infrastructure;
using System.Web.Mvc;
using Oxagile.Internal.MVC.BL.Interfaces;
using Oxagile.Internal.MVC.BL.Services;
using Oxagile.Internal.MVC.Infrastructure.Interfaces;

namespace Oxagile.Internal.MVC.WindsorResolver.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorActionInvoker>().LifeStyle.Transient);

            container.Register(Component.For<IConfigService>().ImplementedBy<ConfigService>().LifeStyle.PerWebRequest);

            container.Register(Component.For<IImageService>()
                    .ImplementedBy<ImageService>()
                    .DependsOn(Dependency.OnAppSettingsValue("imagesFolderPath", "PathToImages"))
                    .LifeStyle.PerWebRequest);

            container.Register(Classes.FromAssemblyContaining(typeof(UserService))
                    .Where(x => x.Name.EndsWith("Service"))
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest());
        }
    }
}

