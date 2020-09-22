using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System.Windows.Media;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    [CommandDisplayName("Push button indicator LED color")]
    [CommandCategory(CommandCategories.ButtonDeck)]
    [CommandCategory(CommandCategories.LEDs)]
    public class SetPushButtonLED : Command
    {
        [CommandParameter("Button row",
            Detail = "Row on which the button exists")]
        public int ButtonRow { get; set; }

        [CommandParameter("Button column",
            Detail = "Column on which the button exists")]
        public int ButtonColumn { get; set; }

        [CommandParameter("Color",
            Detail = "Color to set the LED to (or black to switch off)")]
        public Color Color { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            var ledIndex = commandContext.ButtonDeckInformation.PushButtonLedIndexes[new ButtonPosition(ButtonRow, ButtonColumn)];
            var color = Color.ToRGB();
            commandContext.ButtonDeck.SetLedColor(ledIndex, color);
        }
    }
}
