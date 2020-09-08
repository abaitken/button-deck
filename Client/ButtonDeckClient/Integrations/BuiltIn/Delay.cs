using ButtonDeckClient.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ButtonDeckClient.Integrations.BuiltIn
{
    public class Delay : Command
    {
        public int Time { get; set; }

        public override void Execute()
        {
            if (Time <= 0)
                return;

            Thread.Sleep(Time);
        }
    }
}
