using System;

namespace Blogbook.Infrastructure.ApiLog
{
    public interface IApiLogger
    {
        void Debug(string message);
        void Error(string message, Exception ex);
        void Error(string message);
        void Info(string message);
        void Warn(string message, Exception ex);
        void Warn(string message);
        void Fatal(string message);
        void Fatal(string message, Exception ex);
    }
}