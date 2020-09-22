using System;

namespace ButtonDeckClient.Workflows
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CommandParameterAttribute : Attribute
    {
        public CommandParameterAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
        public string Detail { get; set; }
        // TODO : UI Presentation class
        // TODO : Data validation class
        // TODO : Serialization class
    }
}
