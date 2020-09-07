using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Logging
{
    class LoggerFactory
    {
        public ILogger Create(LogListener listener)
        {
            return new FormattingLogger(new MultiLogger(CreateFileLogger(), listener), (line) => $"{DateTime.Now}: {line}");
        }

        private ILogger CreateFileLogger()
        {
            // TODO : Use settings to determine where the file goes
            return EmptyLogger.Default;
            // TODO : Create file name
            //return new FileLogger("TODO");
        }
    }
}
