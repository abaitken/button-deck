using System;

namespace ButtonDeckClient.Workflows
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandDisplayNameAttribute : Attribute
    {
        public CommandDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }
}
