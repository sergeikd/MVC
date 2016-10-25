using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;

namespace Oxagile.Internal.MVC.WindsorResolver.Installers
{
    public class FluentValidatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof (IValidator<>)).WithService.Base().LifestyleTransient()); //there was transient in the guide, I've changed it
        }
    }
}