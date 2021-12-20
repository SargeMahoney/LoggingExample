using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample.Core
{
    public interface ILoggerEngine
    {
        Task Write(string messageToLog, LogField logField);
    }
}
