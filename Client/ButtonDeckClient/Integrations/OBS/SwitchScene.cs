using ButtonDeckClient.Workflows;
using OBS.WebSocket.NET;

namespace ButtonDeckClient.Integrations.OBS
{
    [CommandDisplayName("OBS Switch scene")]
    [CommandCategory(CommandCategories.OBS)]
    public class SwitchScene : Command
    {
        [CommandParameter("Scene name",
            Detail = "Name of the scene to switch to")]
        public string SceneName { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            commandContext.OBS.SetCurrentScene(SceneName);
        }
    }
}
