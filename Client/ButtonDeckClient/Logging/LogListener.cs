using System;

namespace ButtonDeckClient.Logging
{
    internal class LogListener : ILogger
    {
        public void Dispose()
        {
            // TODO : Do nothing
        }

        public void WriteLine(string message)
        {
            NewLine?.Invoke(this, new LogEventArgs(message));
        }

        public event EventHandler<LogEventArgs> NewLine;
    }
}
