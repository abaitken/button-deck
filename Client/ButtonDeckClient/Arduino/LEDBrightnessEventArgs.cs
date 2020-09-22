using System;

namespace ButtonDeckClient.Arduino
{
    public class LEDBrightnessEventArgs : EventArgs
    {
        public LEDBrightnessEventArgs(int brightness)
        {
            Value = brightness;
        }

        public int Value { get; }
    }

}
