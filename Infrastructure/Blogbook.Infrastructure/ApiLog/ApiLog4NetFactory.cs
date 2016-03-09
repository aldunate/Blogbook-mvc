namespace Blogbook.Infrastructure.ApiLog
{
    public static class ApiLog4NetFactory
    {
        public static IApiLogger DefaultLogger()
        {
            return new ApiLog4NetAdaptor();
        }

        public static IApiLogger CreateFrom(string pathConfig)
        {
            return new ApiLog4NetAdaptor(pathConfig);
        }
        
    }
}