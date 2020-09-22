using System;

namespace ButtonDeckClient.Workflows
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CommandCategoryAttribute : Attribute
    {
        public CommandCategoryAttribute(string category)
        {
            Category = category;
        }

        public string Category { get; }
    }
}
