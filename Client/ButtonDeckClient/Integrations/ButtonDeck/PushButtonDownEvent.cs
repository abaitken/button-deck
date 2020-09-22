using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    public class PushButtonDownEvent : Event
    {
        public override void Subscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ButtonDown += OnButtonDown;
        }

        public override void Unsubscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ButtonDown -= OnButtonDown;
        }

        private void OnButtonDown(object sender, ButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
