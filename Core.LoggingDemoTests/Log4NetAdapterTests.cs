using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.LoggingDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;

namespace Core.LoggingDemo.Tests
{
    [TestClass()]
    public class Log4NetAdapterTests
    {
        [TestMethod()]
        public void LogTest()
        {
            LoggerBuilder.SetAdapter(new Log4NetAdapter());
            ILogger logger = LoggerBuilder.GetLogger(typeof(Log4NetAdapterTests));
            logger.Info("这是一个日志测试信息");
            logger.Debug("这是一个日志调试信息");
            logger.Error("这是一个日志错误信息");
            logger.Fatal("这是一个日志致命错误信息");
        }
    }
}