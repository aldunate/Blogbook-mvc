namespace Blogbook.Infrastructure.Test.ApiIoc.Example
{
    public class DependentClass : IDependentClass
    {
        private readonly IInjectedClass _injectedClass;

        public DependentClass(IInjectedClass injectedClass)
        {
            _injectedClass = injectedClass;
        }

        public string GetValue()
        {
            return _injectedClass.GetValue();
        }

    }
}