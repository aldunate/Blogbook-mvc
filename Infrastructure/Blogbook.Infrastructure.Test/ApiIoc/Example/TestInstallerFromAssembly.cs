using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Blogbook.Infrastructure.Test.ApiIoc.Example
{
    public class TestInstallerFromAssembly : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .Where(Component.IsInSameNamespaceAs<IInjectedClass>())
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromThisAssembly()
                    .Where(Component.IsInSameNamespaceAs<IDependentClass>())
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );
        }
    }
}