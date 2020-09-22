using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    public class ToggleStateChangedEvent : Event
    {
        public override void Subscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ToggleStateChanged += OnToggleStateChanged;
        }

        public override void Unsubscribe(ICommandContext commandContext)
        {
            commandContext.ButtonDeck.ToggleStateChanged -= OnToggleStateChanged;
        }

        private void OnToggleStateChanged(object sender, ToggleStateChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
