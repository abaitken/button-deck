using System;

namespace ButtonDeckClient.Logging
{
    internal class FormattingLogger : ILogger
    {
        private readonly ILogger _parent;
        private readonly Func<string, string> _format;

        public FormattingLogger(ILogger parent, Func<string, string> format)
        {
            _parent = parent;
            _format = format;
        }
        public void Dispose()
        {
            // Do nothing
        }

        public void WriteLine(string message)
        {
            _parent.WriteLine(_format(message));
        }
    }
}
