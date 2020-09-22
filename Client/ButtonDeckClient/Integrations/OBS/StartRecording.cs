using ButtonDeckClient.Workflows;

namespace ButtonDeckClient.Integrations.OBS
{
    [CommandDisplayName("OBS Start recording")]
    [CommandCategory(CommandCategories.OBS)]
    public class StartRecording : Command
    {
        public override void Execute(ICommandContext commandContext)
        {
            commandContext.OBS.StartRecording();
        }
    }
}
