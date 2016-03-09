namespace Blogbook.Infrastructure.Test.ApiIoc.Example
{
    public class InjectedClass : IInjectedClass
    {
        public string GetValue()
        {
            return "TheValue";
        }
    }
}