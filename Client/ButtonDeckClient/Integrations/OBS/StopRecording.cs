using ButtonDeckClient.Workflows;
using OBS.WebSocket.NET;

namespace ButtonDeckClient.Integrations.OBS
{
    public class StopRecording : Command
    {
        public ObsWebSocketApi OBS { get; set; }

        public override void Execute()
        {
            OBS.StopRecording();
        }
    }
}
