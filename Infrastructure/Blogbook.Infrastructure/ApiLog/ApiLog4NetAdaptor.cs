using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Blogbook.Infrastructure.ApiLog
{
    public class ApiLog4NetAdaptor : IApiLogger
    {
        private readonly ILog _log;
        public ApiLog4NetAdaptor()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(ApiLog4NetAdaptor));
        }

        public ApiLog4NetAdaptor(string pathConfig)
        {
            var fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathConfig));
            XmlConfigurator.Configure(fileInfo);
            _log = LogManager.GetLogger(typeof (ApiLog4NetAdaptor));
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _log.Fatal(message, exception);
        }
    }
}