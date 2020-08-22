using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Logging
{
    public interface ILogger : IDisposable
    {
        void WriteLine(string message);
    }
}
