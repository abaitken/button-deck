namespace ButtonDeckClient.Logging
{
    internal class CategoryLogger : ILogger
    {
        private readonly string _category;
        private readonly ILogger _parent;

        public CategoryLogger(string category, ILogger parent)
        {
            _category = category;
            _parent = parent;
        }

        public void Dispose()
        {
            // Do nothing
        }

        public void WriteLine(string message)
        {
            _parent.WriteLine($"{_category}: {message}");
        }

        public static ILogger Create(string category, ILogger parent)
        {
            if (parent == EmptyLogger.Default)
                return EmptyLogger.Default;

            return new CategoryLogger(category, parent);
        }
    }
}
