using Castle.MicroKernel.Facilities;

namespace Blogbook.Infrastructure.ApiLog
{
    public class ApiLogWindsorFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Resolver.AddSubResolver(new ApiSubDependencyResolver());
        }
    }
}