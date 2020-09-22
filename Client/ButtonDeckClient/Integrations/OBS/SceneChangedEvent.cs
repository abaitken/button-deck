using ButtonDeckClient.Workflows;
using OBS.WebSocket.NET;
using System;

namespace ButtonDeckClient.Integrations.OBS
{
    public class SceneChangedEvent : Event
    {
        public override void Subscribe(ICommandContext commandContext)
        {
            commandContext.OBSWebSocket.SceneChanged += OnSceneChanged;
        }

        public override void Unsubscribe(ICommandContext commandContext)
        {
            commandContext.OBSWebSocket.SceneChanged -= OnSceneChanged;
        }

        private void OnSceneChanged(ObsWebSocket sender, string newSceneName)
        {
            throw new NotImplementedException();
        }
    }
}
