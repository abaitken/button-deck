using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System.Windows.Media;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    [CommandDisplayName("Status indicator LED color")]
    [CommandCategory(CommandCategories.ButtonDeck)]
    [CommandCategory(CommandCategories.LEDs)]
    public class SetStatusLED : Command
    {
        [CommandParameter("Status indicator index",
            Detail = "Index of the status indicator")]
        public int StatusIndex { get; set; }

        [CommandParameter("Color",
            Detail = "Color to set the LED to (or black to switch off)")]
        public Color Color { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            var ledIndex = commandContext.ButtonDeckInformation.StatusLedIndexes[StatusIndex];
            var color = Color.ToRGB();
            commandContext.ButtonDeck.SetLedColor(ledIndex, color);
        }
    }
}
