using ButtonDeckClient.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButtonDeckClient.Integrations.BuiltIn
{
    [CommandDisplayName("Wait")]
    [CommandCategory(CommandCategories.General)]
    [CommandCategory(CommandCategories.BuiltIn)]
    public class Delay : Command
    {
        [CommandParameter("Delay (ms)", 
            Detail = "Time in milliseconds (1000 = 1 second) to wait before executing the next command")]
        public int Time { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            if (Time <= 0)
                return;

            // TODO : This may not be ideal.
            // Potentially these commands would return tasks that get executed so that the caller will wait for them?
            // Or instead raise an event after each command completes and execute a sleep on a new thread instead?
            Thread.Sleep(Time);
        }
    }
}
