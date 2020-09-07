namespace ButtonDeckClient.Logging
{
    internal class EmptyLogger : ILogger
    {
        public static readonly ILogger Default = new EmptyLogger();

        public void Dispose()
        {
            // Do nothing
        }

        public void WriteLine(string message)
        {
            // Do nothing
        }
    }
}
