using System;

namespace ButtonDeckClient.Arduino
{
    internal class LEDBrightnessEventArgs : EventArgs
    {
        public LEDBrightnessEventArgs(int brightness)
        {
            Brightness = brightness;
        }

        public int Brightness { get; }
    }

}
