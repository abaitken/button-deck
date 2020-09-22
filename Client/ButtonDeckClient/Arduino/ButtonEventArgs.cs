using System;

namespace ButtonDeckClient.Arduino
{
    public class ButtonEventArgs : EventArgs
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
