using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logging
{
    public interface ILogAdapter
    {
        ILogger GetLogger(string loggername);
    }
}
