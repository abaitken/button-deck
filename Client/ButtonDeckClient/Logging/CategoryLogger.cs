namespace ButtonDeckClient.Logging
{
    public class CategoryLogger : ILogger
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
    }
}
