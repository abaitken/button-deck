using System;

namespace ButtonDeckClient.Arduino
{
    internal class ButtonEventArgs : EventArgs
    {
        public ButtonEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }

}
