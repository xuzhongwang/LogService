using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logging
{
    public interface ILogger
    {
        void Debug(string message);

        void Info(string message);

        void Error(string message);

        void Fatal(string message);

    }
}
