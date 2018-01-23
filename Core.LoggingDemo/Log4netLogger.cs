using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using Utility.Logging;

namespace Core.LoggingDemo
{
    public class Log4NetLogger:IOutLogger
    {
        private static readonly Type DeclaringType = typeof(Log4NetLogger);
        private log4net.Core.ILogger _logger;
        public Log4NetLogger(string loggername)
        {
            _logger = log4net.LogManager.GetLogger(loggername).Logger;
        }
        public void Debug(string message)
        {
            if (IsDebugEnabled)
            {
                WriteLog(LogLevel.Debug, message, null);
            }
        }

        public void Info(string message)
        {
            if (IsDebugEnabled)
            {
                WriteLog(LogLevel.Info, message, null);
            }
        }

        public void Error(string message)
        {
            if (IsErrorEnabled)
            {
                WriteLog(LogLevel.Error, message, null);
            };
        }

        public void Fatal(string message)
        {
            if (IsFatalEnabled)
            {
                WriteLog(LogLevel.Fatal, message, null);
            };
        }

        public void WriteLog(LogLevel level,string message,Exception exception)
        {
            Level log4Level = LevelMap(level);
            _logger.Log(DeclaringType, log4Level, message, exception);
        }

        /// <summary>
        /// 获取日志输出级别
        /// </summary>
        /// <param name="level">日志输出级别枚举</param>
        /// <returns>Log4日志输出级别</returns>
        private Level LevelMap(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.All:
                    return Level.All;
                case LogLevel.Trace:
                    return Level.Trace;
                case LogLevel.Debug:
                    return Level.Debug;
                case LogLevel.Info:
                    return Level.Info;
                case LogLevel.Warn:
                    return Level.Warn;
                case LogLevel.Error:
                    return Level.Error;
                case LogLevel.Fatal:
                    return Level.Fatal;
                case LogLevel.Off:
                    return Level.Off;
                default:
                    return Level.Off;
            }
        }

        public bool IsDebugEnabled => _logger.IsEnabledFor(Level.Debug);
        public bool IsInfoEnabled => _logger.IsEnabledFor(Level.Info);
        public bool IsWarnEnabled => _logger.IsEnabledFor(Level.Warn);
        public bool IsErrorEnabled => _logger.IsEnabledFor(Level.Error);
        public bool IsFatalEnabled => _logger.IsEnabledFor(Level.Fatal);
    }
}
