namespace ButtonDeckClient.Logging
{
    internal class MultiLogger : ILogger
    {
        private readonly ILogger[] _loggers;

        public MultiLogger(params ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public void Dispose()
        {
            // Do nothing
        }

        public void WriteLine(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.WriteLine(message);
            }
        }
    }
}
