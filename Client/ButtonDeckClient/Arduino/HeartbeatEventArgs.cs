using System;

namespace ButtonDeckClient.Arduino
{
    public class HeartbeatEventArgs : EventArgs
    {
        public HeartbeatEventArgs(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

}
