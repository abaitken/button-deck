using System.Collections.Generic;

namespace ButtonDeckClient
{
    struct ButtonDeckInformation
    {
        public ButtonDeckInformation(int toggleSwitchCount, int pushButtonRows, int pushButtonCols, int[] statusLedIndexes, Mapping<ButtonPosition, int> pushButtonLedIndexes, Mapping<int, int> toggleSwitchLedIndexes)
        {
            ToggleSwitchCount = toggleSwitchCount;
            PushButtonRows = pushButtonRows;
            PushButtonCols = pushButtonCols;
            StatusLedIndexes = statusLedIndexes;
            PushButtonLedIndexes = pushButtonLedIndexes;
            ToggleSwitchLedIndexes = toggleSwitchLedIndexes;
        }

        public int ToggleSwitchCount { get; }
        public int PushButtonRows { get; }
        public int PushButtonCols { get; }
        public int[] StatusLedIndexes { get; }
        public Mapping<ButtonPosition, int> PushButtonLedIndexes { get; }
        public Mapping<int, int> ToggleSwitchLedIndexes { get; }

        // TODO : Find a better way to encode this information. Maybe a configuration file?
        public static readonly ButtonDeckInformation Default = new ButtonDeckInformation(8, 5, 5,
            new[] { 0, 1, 2 },
            new Mapping<ButtonPosition, int>
            {
                { new ButtonPosition(0,0), 3 },
                { new ButtonPosition(0,1), 4 },
                { new ButtonPosition(0,2), 5 },
                { new ButtonPosition(0,3), 6 },
                { new ButtonPosition(0,4), 7 },
                { new ButtonPosition(1,0), 12 },
                { new ButtonPosition(1,1), 11 },
                { new ButtonPosition(1,2), 10 },
                { new ButtonPosition(1,3), 9 },
                { new ButtonPosition(1,4), 8 },
                { new ButtonPosition(2,0), 13 },
                { new ButtonPosition(2,1), 14 },
                { new ButtonPosition(2,2), 15 },
                { new ButtonPosition(2,3), 16 },
                { new ButtonPosition(2,4), 17 },
                { new ButtonPosition(3,0), 27 },
                { new ButtonPosition(3,1), 26 },
                { new ButtonPosition(3,2), 25 },
                { new ButtonPosition(3,3), 24 },
                { new ButtonPosition(3,4), 23 },
                { new ButtonPosition(4,0), 28 },
                { new ButtonPosition(4,1), 29 },
                { new ButtonPosition(4,2), 30 },
                { new ButtonPosition(4,3), 31 },
                { new ButtonPosition(4,4), 32 },
            },
            new Mapping<int, int>
            {
                { 4, 18 },
                { 3, 19 },
                { 2, 20 },
                { 1, 21 },
                { 0, 22 },
            }
            );
    }

    struct ButtonPosition
    {
        public ButtonPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }

    class Mapping<T1, T2> : Dictionary<T1, T2>
    {
    }
}
