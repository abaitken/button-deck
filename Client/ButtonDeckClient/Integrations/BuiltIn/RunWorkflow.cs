using ButtonDeckClient.Workflows;
using System;

namespace ButtonDeckClient.Integrations.BuiltIn
{
    [CommandDisplayName("Run Workflow")]
    [CommandCategory(CommandCategories.General)]
    [CommandCategory(CommandCategories.BuiltIn)]
    public class RunWorkflow : Command
    {
        [CommandParameter("Workflow name",
            Detail = "Name of the workflow to run")]
        public string Name { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            throw new NotImplementedException();
        }
    }
}
