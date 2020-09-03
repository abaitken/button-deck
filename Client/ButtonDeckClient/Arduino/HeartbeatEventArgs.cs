using System;

namespace ButtonDeckClient.Arduino
{
    internal class HeartbeatEventArgs : EventArgs
    {
        public HeartbeatEventArgs(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

}
