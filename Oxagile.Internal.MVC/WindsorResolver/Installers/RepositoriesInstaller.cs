using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Oxagile.Internal.MVC.DALCF;
using System.Data.Entity;
using Oxagile.Internal.MVC.DALCF.Repositories;

namespace Oxagile.Internal.MVC.WindsorResolver.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DbContext>().ImplementedBy<AppContext>().LifeStyle.PerWebRequest);
            container.Register(
                Classes.FromAssemblyContaining(typeof (BaseRepository<>))
                    .Where(x => x.Name.EndsWith("Repository"))
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest());
        }
    }
}