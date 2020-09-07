using System;

namespace ButtonDeckClient.Arduino
{
    internal class LEDBrightnessEventArgs : EventArgs
    {
        public LEDBrightnessEventArgs(int brightness)
        {
            Value = brightness;
        }

        public int Value { get; }
    }

}
