using System.Windows.Media;

namespace ButtonDeckClient.Arduino
{
    internal static class ColorExtensions
    {
        public static RGB ToRGB(this Color value)
        {
            return new RGB(value.R, value.G, value.B);
        }
    }
}
