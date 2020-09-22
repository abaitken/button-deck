using System;
using System.Collections.Generic;

namespace ButtonDeckClient.Workflows
{
    public class Workflow
    {
        public Type Event { get; set; }
        public string Name { get; set; }
        public List<Command> Commands { get; set; }
    }
}
