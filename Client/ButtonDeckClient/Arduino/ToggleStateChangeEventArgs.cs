using System;

namespace ButtonDeckClient.Arduino
{
    public class ToggleStateChangeEventArgs : EventArgs
    {
        public ToggleStateChangeEventArgs(int index, bool newState)
        {
            Index = index;
            NewState = newState;
        }

        public int Index { get; }
        public bool NewState { get; }
    }

}
