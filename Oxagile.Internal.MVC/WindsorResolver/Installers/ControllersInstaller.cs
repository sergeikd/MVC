using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;

namespace Oxagile.Internal.MVC.WindsorResolver.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes
                    .FromThisAssembly()
                    .BasedOn<IController>()
                    .LifestyleTransient());
        }
    }
}