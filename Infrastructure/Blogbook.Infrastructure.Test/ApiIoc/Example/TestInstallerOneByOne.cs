using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Blogbook.Infrastructure.Test.ApiIoc.Example
{
    public class TestInstallerOneByOne : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IInjectedClass>()
                    .ImplementedBy<InjectedClass>()
                    .LifestyleTransient(),
                Component.For<IDependentClass>()
                    .ImplementedBy<DependentClass>()
                    .LifestyleTransient()
                );
        }
    }
}