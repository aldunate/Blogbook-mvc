using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace Blogbook.Infrastructure.ApiLog
{
    public class ApiSubDependencyResolver : ISubDependencyResolver
    {
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, 
                                ComponentModel model, DependencyModel dependency)
        {
            return ApiLog.Instance;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, 
                                ComponentModel model, DependencyModel dependency)
        {
            return dependency.TargetType == typeof(IApiLogger);
        }
    }
}