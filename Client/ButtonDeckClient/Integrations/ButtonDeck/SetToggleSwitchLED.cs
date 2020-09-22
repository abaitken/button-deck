using ButtonDeckClient.Arduino;
using ButtonDeckClient.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ButtonDeckClient.Integrations.ButtonDeck
{
    [CommandDisplayName("Toggle switch indicator LED color")]
    [CommandCategory(CommandCategories.ButtonDeck)]
    [CommandCategory(CommandCategories.LEDs)]
    public class SetToggleSwitchLED : Command
    {
        public int ToggleIndex { get; set; }

        [CommandParameter("Color",
            Detail = "Color to set the LED to (or black to switch off)")]
        public Color Color { get; set; }

        public override void Execute(ICommandContext commandContext)
        {
            var ledIndex = commandContext.ButtonDeckInformation.ToggleSwitchLedIndexes[ToggleIndex];
            var color = Color.ToRGB();
            commandContext.ButtonDeck.SetLedColor(ledIndex, color);
        }
    }
}
