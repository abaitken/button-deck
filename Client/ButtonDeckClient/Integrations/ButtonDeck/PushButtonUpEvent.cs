using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    public class PushButtonUpEvent : Event
    {
        public override void Subscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ButtonUp += OnButtonUp;
        }

        public override void Unsubscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ButtonUp -= OnButtonUp;
        }

        private void OnButtonUp(object sender, ButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
