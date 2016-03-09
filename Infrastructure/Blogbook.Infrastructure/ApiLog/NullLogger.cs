using System;

namespace Blogbook.Infrastructure.ApiLog
{

    public class NullApiLogger : IApiLogger
    {
        public void Debug(string message)
        {
            
        }

        public void Error(string message, Exception ex)
        {
            
        }

        public void Error(string message)
        {
            
        }

        public void Info(string message)
        {
            
        }

        public void Warn(string message, Exception ex)
        {
            
        }

        public void Warn(string message)
        {
           
        }

        public void Fatal(string message)
        {
            
        }

        public void Fatal(string message, Exception ex)
        {
           
        }
    }
}