using ButtonDeckClient.Workflows;
using OBS.WebSocket.NET;

namespace ButtonDeckClient.Integrations.OBS
{
    [CommandDisplayName("OBS Stop recording")]
    [CommandCategory(CommandCategories.OBS)]
    public class StopRecording : Command
    {
        public override void Execute(ICommandContext commandContext)
        {
            commandContext.OBS.StopRecording();
        }
    }
}
