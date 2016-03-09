namespace Blogbook.Infrastructure.ApiLog
{
    public static class ApiLog
    {

        static ApiLog()
        {
            Instance = new NullApiLogger();
        }

        public static IApiLogger Instance { get; private set; }
        public static void Create(IApiLogger apiLogger)
        {
            Instance = apiLogger;
        }

    }
}