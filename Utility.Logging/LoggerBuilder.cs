using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logging
{
    public static class LoggerBuilder
    {
        private static readonly ConcurrentDictionary<string, ILogger> _loggers;
        private static ILogAdapter _loggeradapter;
        private static readonly object _lockobj = new object();

        static LoggerBuilder()
        {
            _loggers  = new ConcurrentDictionary<string, ILogger>();
        }

        public static ILogger GetLogger(string loggername)
        {
            lock (_lockobj)
            {
                ILogger logger;
                if (_loggers.TryGetValue(loggername,out logger))
                {
                    return logger;
                }
                logger = _loggeradapter.GetLogger(loggername);
                _loggers[loggername] = logger;
                return logger;
            }
        }

        public static ILogger GetLogger(Type loggertype)
        {
            return GetLogger(loggertype.FullName);
        }

        public static void SetAdapter(ILogAdapter adapter)
        {
            _loggeradapter = adapter;
            _loggers.Clear();
        }
    }
}
