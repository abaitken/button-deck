using System;

namespace ButtonDeckClient.Logging
{
    internal class LogEventArgs : EventArgs
    {
        public LogEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}