using ButtonDeckClient.Workflows;

namespace ButtonDeckClient.Integrations.OBS
{
    [CommandDisplayName("OBS Toggle source visibiilty")]
    [CommandCategory(CommandCategories.OBS)]
    public class ToggleSourceVisibility : Command
    {
        [CommandParameter("Scene name",
            Detail = "Name of the scene which contains the source")]
        public string SceneName { get; set; }

        [CommandParameter("Source name",
            Detail = "Name of the source to toggle visibility")]
        public string SourceName { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            // TODO : Implement this
        }
    }
}
