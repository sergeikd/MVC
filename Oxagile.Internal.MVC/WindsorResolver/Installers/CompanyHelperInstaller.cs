using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Oxagile.Internal.MVC.Helpers.Interfaces;

namespace Oxagile.Internal.MVC.WindsorResolver.Installers
{
    public class CompanyHelperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof(ICompaniesHelper))
                .Where(x=> x.Name.EndsWith("Helper"))
                .WithServiceAllInterfaces()
                .LifestylePerWebRequest());
        }
    }
}